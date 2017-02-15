using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScenarioViewer.Model.Readers
{
    class DB4SparseReader : IWowClientDBReader
    {
        private const int HeaderSize = 52;
        public const uint DB4FmtSig = 0x34424457;          // WDB4

        public int RecordsCount { get; private set; }
        public int FieldsCount { get; private set; }
        public int RecordSize { get; private set; }
        public int StringTableSize { get; private set; }
        public bool HasSeparateIndexColumn { get { return true; } }
        public bool HasInlineStrings { get { return true; } }

        public Dictionary<int, string> StringTable { get; private set; }

        private SortedDictionary<int, byte[]> RowData = new SortedDictionary<int, byte[]>();

        public IEnumerable<BinaryReader> Rows
        {
            get
            {
                foreach(var row in RowData)
                {
                    yield return new BinaryReader(new MemoryStream(row.Value), Encoding.UTF8);
                }
            }
        }

        public string GetIntLength(int index)
        {
            return null;
        }

        public DB4SparseReader(string fileName)
        {
            using (var reader = BinaryReaderExtensions.FromFile(fileName))
            {
                if (reader.BaseStream.Length < HeaderSize)
                {
                    throw new InvalidDataException(String.Format("File {0} is corrupted!", fileName));
                }

                if (reader.ReadUInt32() != DB4FmtSig)
                {
                    throw new InvalidDataException(String.Format("File {0} isn't valid DB4 sparse file!", fileName));
                }

                RecordsCount = reader.ReadInt32();
                FieldsCount = reader.ReadInt32();
                RecordSize = reader.ReadInt32();
                int offsetsPos = reader.ReadInt32();

                uint tableHash = reader.ReadUInt32();
                uint build = reader.ReadUInt32();
                uint unk1 = reader.ReadUInt32();

                int MinId = reader.ReadInt32();
                int MaxId = reader.ReadInt32();
                int locale = reader.ReadInt32();
                int CopyTableSize = reader.ReadInt32();
                int metaFlags = reader.ReadInt32();

                reader.BaseStream.Position = offsetsPos;

                var numOffsets = MaxId - MinId + 1;
                for (var i = 0; i < numOffsets; ++i)
                {
                    var offset = reader.ReadInt32();
                    var length = reader.ReadUInt16();
                    if (offset != 0 && length != 0)
                    {
                        var rowData = reader.ReadBytesAt(offset, length);
                        var rowDataWithId = new byte[length + 4];

                        Array.Copy(BitConverter.GetBytes(MinId + i), rowDataWithId, 4);
                        Array.Copy(rowData, 0, rowDataWithId, 4, rowData.Length);

                        RowData.Add(MinId + i, rowDataWithId);
                    }
                }

                RecordsCount = RowData.Count;
            }
        }
    }
}
