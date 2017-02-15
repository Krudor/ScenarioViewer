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
    public class ScenarioStep : IDBObjectReader
    {
        public const string FileName = @"ScenarioStep.db2";

        public uint Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ushort CriteriaTreeId { get; set; }
        public CriteriaTree CriteriaTree { get; set; }
        public uint ScenarioId { get; set; }
        public Scenario Scenario { get; set; }
        public uint PreviousStepId { get; set; }
        public ScenarioStep PreviousStep { get; set; }
        public ushort QuestRewardId { get; set; }
        public byte StepIndex { get; set; }
        public ScenarioStepFlag Flags { get; set; }
        public uint BonusObjectiveRequiredStepId { get; set; }
        public ScenarioStep BonusObjectiveRequiredStep { get; set; }

        public string Value => Id.ToString();
        public string Display => $"{Id} - {Name}";

        public void ReadObject(IWowClientDBReader dbReader, BinaryReader reader, IDBCDataProvider dbcDataProvider, IDBDataProvider dbDataProvider)
        {
            using (BinaryReader br = reader)
            {
                if (dbReader.HasSeparateIndexColumn)
                    Id = br.ReadUInt32();

                if (dbReader.HasInlineStrings)
                    Description = br.ReadStringNull();
                else if (dbReader is STLReader)
                {
                    int offset = br.ReadInt32();
                    Description = (dbReader as STLReader).ReadString(offset);
                }
                else
                {
                    Description = dbReader.StringTable[br.ReadInt32()];
                }

                if (dbReader.HasInlineStrings)
                    Name = br.ReadStringNull();
                else if (dbReader is STLReader)
                {
                    int offset = br.ReadInt32();
                    Name = (dbReader as STLReader).ReadString(offset);
                }
                else
                {
                    Name = dbReader.StringTable[br.ReadInt32()];
                }

                CriteriaTreeId = br.ReadUInt16();
                ScenarioId = (uint)br.ReadInt16();
                PreviousStepId = (uint)br.ReadInt16();
                QuestRewardId = br.ReadUInt16();
                StepIndex = br.ReadByte();
                Flags = (ScenarioStepFlag)br.ReadByte();
                BonusObjectiveRequiredStepId = (uint)br.ReadInt16();
            }
        }
    }

    [Flags]
    public enum ScenarioStepFlag : byte
    {
        [Description("Bonus Objective")]
        BonusObjective  = 0x1,
        [Description("Unknown 2")]
        Unk2            = 0x2,
    }
}
