using System;
using System.IO;
using System.Xml;
using ScenarioViewer.Model.Readers;

namespace ScenarioViewer.Model.Readers
{
    public class DBReaderFactory
    {
        public static IWowClientDBReader GetReader(string file, XmlElement definition)
        {
            IWowClientDBReader reader;

            var ext = Path.GetExtension(file).ToUpperInvariant();
            if (ext == ".DBC")
                reader = new DBCReader(file);
            else if (ext == ".DB2")
            {
                using (var binaryReader = BinaryReaderExtensions.FromFile(file))
                {
                    switch (binaryReader.ReadUInt32())
                    {
                        case DB2Reader.DB2FmtSig:
                        {
                            reader = new DB2Reader(file);
                            break;
                        }
                        case DB3Reader.DB3FmtSig:
                        {
                            reader = new DB2Reader(file);
                            break;
                        }
                        case DB4Reader.DB4FmtSig:
                        {
                            try
                            {
                                reader = new DB4Reader(file);
                            }
                            catch
                            {
                                reader = new DB4SparseReader(file);
                            }
                            break;
                        }
                        case DB5Reader.DB5FmtSig:
                        {
                            try
                            {
                                reader = new DB5Reader(file, definition);
                            }
                            catch
                            {
                                reader = new DB5SparseReader(file);
                            }
                            break;
                        }
                        default:
                            throw new InvalidDataException(string.Format("Unknown file type {0}", ext));
                    }
                }
            }
            else if (ext == ".ADB")
                reader = new ADBReader(file);
            else if (ext == ".WDB")
                reader = new WDBReader(file);
            else if (ext == ".STL")
                reader = new STLReader(file);
            else
                throw new InvalidDataException(String.Format("Unknown file type {0}", ext));

            return reader;
        }
    }
}
