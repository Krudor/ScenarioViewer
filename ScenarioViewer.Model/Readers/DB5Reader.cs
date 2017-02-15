using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace ScenarioViewer.Model.Readers
{
    class DB5Reader : IWowClientDBReader
    {
        private const int HeaderSize = 48;
        public const uint DB5FmtSig = 0x35424457;          // WDB5

        public int RecordsCount { get; private set; }
        public int FieldsCount { get; private set; }
        public int RecordSize { get; private set; }
        public int StringTableSize { get; private set; }
        public bool HasSeparateIndexColumn { get; private set; }
        public bool HasInlineStrings { get { return false; } }

        public Dictionary<int, string> StringTable { get; private set; }

        private SortedDictionary<int, byte[]> Lookup = new SortedDictionary<int, byte[]>();

        private short[] FieldOffsets { get; set; }
        private short[] FieldBitSizes { get; set; }

        public IEnumerable<BinaryReader> Rows
        {
            get
            {
                foreach(var row in Lookup)
                {
                    yield return new BinaryReader(new MemoryStream(row.Value), Encoding.UTF8);
                }
            }
        }

        public string GetIntLength(int index)
        {
            switch (4 - FieldBitSizes[index] / 8)
            {
                case 1:
                    return "byte";
                case 2:
                    return "short";
                case 3:
                    return "int24";
                case 4:
                    return "int";
                default:
                    break;
            }

            return null;
        }

        public DB5Reader(string fileName, XmlElement definition)
        {
            var fields = definition.GetElementsByTagName("field");

            var db5index = 0;
            XmlNodeList indexes = definition.GetElementsByTagName("index");
            if (indexes.Count == 1)
            {
                for (var j = 0; j < fields.Count; ++j)
                {
                    if (fields[j].Attributes["name"].Value == indexes[0]["primary"].InnerText)
                    {
                        db5index = j;
                        break;
                    }
                }
            }

            using (var reader = BinaryReaderExtensions.FromFile(fileName))
            {
                if (reader.BaseStream.Length < HeaderSize)
                {
                    throw new InvalidDataException(string.Format("File {0} is corrupted!", fileName));
                }

                if (reader.ReadUInt32() != DB5FmtSig)
                {
                    throw new InvalidDataException(string.Format("File {0} isn't valid DB5 file!", fileName));
                }

                RecordsCount = reader.ReadInt32();
                FieldsCount = reader.ReadInt32();
                RecordSize = reader.ReadInt32();
                StringTableSize = reader.ReadInt32();

                uint tableHash = reader.ReadUInt32();
                uint build = reader.ReadUInt32();

                int MinId = reader.ReadInt32();
                int MaxId = reader.ReadInt32();
                int locale = reader.ReadInt32();
                int CopyTableSize = reader.ReadInt32();
                int metaFlags = reader.ReadInt32();

                FieldOffsets = new short[FieldsCount];
                FieldBitSizes = new short[FieldsCount];

                for (var i = 0; i < FieldsCount; ++i)
                {
                    FieldBitSizes[i] = reader.ReadInt16();
                    FieldOffsets[i] = reader.ReadInt16();
                }

                var headerEnd = reader.BaseStream.Position;

                var stringTableStart = headerEnd + RecordsCount * RecordSize;
                var stringTableEnd = stringTableStart + StringTableSize;

                // Index table
                int[] m_indexes = null;
                HasSeparateIndexColumn = stringTableEnd + CopyTableSize < reader.BaseStream.Length;

                if (HasSeparateIndexColumn)
                {
                    reader.BaseStream.Position = stringTableEnd;

                    m_indexes = new int[RecordsCount];

                    for (int i = 0; i < RecordsCount; i++)
                        m_indexes[i] = reader.ReadInt32();
                }

                // Records table
                reader.BaseStream.Position = headerEnd;

                for (int i = 0; i < RecordsCount; i++)
                {
                    byte[] recordBytes = reader.ReadBytes(RecordSize);

                    if (HasSeparateIndexColumn)
                    {
                        byte[] newRecordBytes = new byte[RecordSize + 4];

                        Array.Copy(BitConverter.GetBytes(m_indexes[i]), newRecordBytes, 4);
                        Array.Copy(recordBytes, 0, newRecordBytes, 4, recordBytes.Length);

                        Lookup.Add(m_indexes[i], newRecordBytes);
                    }
                    else
                    {
                        var idBytes = new byte[4];
                        Array.Copy(recordBytes, FieldOffsets[db5index], idBytes, 0, 4 - FieldBitSizes[db5index] / 8);
                        Lookup.Add(BitConverter.ToInt32(idBytes, 0), recordBytes);
                    }
                }

                // Strings table
                reader.BaseStream.Position = stringTableStart;

                StringTable = new Dictionary<int, string>();

                while (reader.BaseStream.Position != stringTableEnd)
                {
                    int index = (int)(reader.BaseStream.Position - stringTableStart);
                    StringTable[index] = reader.ReadStringNull();
                }

                // Copy index table
                long copyTablePos = stringTableEnd + (HasSeparateIndexColumn ? 4 * RecordsCount : 0);

                if (copyTablePos != reader.BaseStream.Length && CopyTableSize != 0)
                {
                    reader.BaseStream.Position = copyTablePos;

                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        try
                        {
                            int id = reader.ReadInt32();
                            int idcopy = reader.ReadInt32();

                            byte[] copyRow = Lookup[idcopy];
                            byte[] newRow = new byte[copyRow.Length];
                            Array.Copy(copyRow, newRow, newRow.Length);
                            Array.Copy(BitConverter.GetBytes(id), newRow, 4);

                            Lookup.Add(id, newRow);
                            RecordsCount++;
                        }
                        catch (KeyNotFoundException)
                        {
                        }
                    }
                }
            }
        }
    }
}
