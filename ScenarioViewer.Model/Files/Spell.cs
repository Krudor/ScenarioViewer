using ScenarioViewer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioViewer.Model.Readers;

namespace ScenarioViewer.Model.Files
{
    public class Spell : IDBObjectReader
    {
        public const string FileName = @"Spell.db2";
        
        public string Name { get; set; }
        public string NameSubtext { get; set; }
        public string Description { get; set; }
        public string AuraDescription { get; set; }
        public uint MiscId { get; set; }
        public uint Id { get; set; }
        public uint DescriptionVariablesId { get; set; }

        private IDBCDataProvider _dbcDataProvider;
        private IDBDataProvider _dbDataProvider;
        
        public void ReadObject(IWowClientDBReader dbReader, BinaryReader binaryReader, IDBCDataProvider dbcDataProvider, IDBDataProvider dbDataProvider)
        {
            _dbcDataProvider = dbcDataProvider;
            _dbDataProvider = dbDataProvider;

            using (BinaryReader br = binaryReader)
            {
                if (dbReader.HasInlineStrings)
                {
                    Name = br.ReadStringNull();
                    NameSubtext = br.ReadStringNull();
                    Description = br.ReadStringNull();
                    AuraDescription = br.ReadStringNull();
                }
                else if (dbReader is STLReader)
                {
                    Name = (dbReader as STLReader).ReadString(br.ReadInt32());
                    NameSubtext = (dbReader as STLReader).ReadString(br.ReadInt32());
                    Description = (dbReader as STLReader).ReadString(br.ReadInt32());
                    AuraDescription = (dbReader as STLReader).ReadString(br.ReadInt32());
                }
                else
                {
                    Name = dbReader.StringTable[br.ReadInt32()];
                    NameSubtext = dbReader.StringTable[br.ReadInt32()];
                    Description = dbReader.StringTable[br.ReadInt32()];
                    AuraDescription = dbReader.StringTable[br.ReadInt32()];
                }

                MiscId = br.ReadUInt32();
                Id = br.ReadUInt32();
                DescriptionVariablesId = br.ReadUInt32();
            }
        }
    }
}
