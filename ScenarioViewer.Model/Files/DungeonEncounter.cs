using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioViewer.Model.Readers;

namespace ScenarioViewer.Model.Files
{
    public class DungeonEncounter : IDBObjectReader
    {
        public const string FileName = @"DungeonEncounter.db2";
        
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint CreatureDisplayId { get; set; }
        public ushort MapId { get; set; }
        public ushort SpellIconId { get; set; }
        public byte Bit { get; set; }
        public byte Flags { get; set; }
        public int OrderIndex { get; set; }
        
        public string Value => Id.ToString();

        public string Display => $"{Id} - {Name}";

        public void ReadObject(IWowClientDBReader dbReader, BinaryReader reader, IDBCDataProvider dbcDataProvider, IDBDataProvider dbDataProvider)
        {
            using (BinaryReader br = reader)
            {
                if (dbReader.HasSeparateIndexColumn)
                    Id = br.ReadUInt32();
                else
                    Id = br.ReadUInt32();

                if (dbReader.HasInlineStrings)
                    Name = br.ReadStringNull();
                else if (dbReader is STLReader)
                {
                    int offset = br.ReadInt32();
                    Name = (dbReader as STLReader).ReadString(offset);
                }
                else
                {
                    int something = br.ReadInt32();
                    if (dbReader.StringTable.ContainsKey(something))
                        Name = dbReader.StringTable[something];
                }

                CreatureDisplayId = br.ReadUInt32();
                MapId = br.ReadUInt16();
                SpellIconId = br.ReadUInt16();
                Bit = br.ReadByte();
                Flags = br.ReadByte();
                OrderIndex = br.ReadInt32();
            }
        }
    }
}
