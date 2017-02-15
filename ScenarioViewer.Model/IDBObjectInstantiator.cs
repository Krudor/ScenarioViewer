using System.IO;
using ScenarioViewer.Model.Readers;

namespace ScenarioViewer.Model
{
    public interface IDBObjectReader
    {
        void ReadObject(IWowClientDBReader dbReader, BinaryReader reader, IDBCDataProvider dbcDataProvider, IDBDataProvider dbDataProvider);
    }
}