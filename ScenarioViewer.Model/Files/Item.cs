using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioViewer.Model.Readers;

namespace ScenarioViewer.Model.Files
{
    public class Item : IDBObjectReader
    {
        public static string FileName => "Item-sparse.db2";

        public uint Id { get; set; }
        public uint[] Flags { get; set; }
        public float Unk1 { get; set; }
        public float Unk2 { get; set; }
        public uint BuyPrice { get; set; }
        public uint SellPrice { get; set; }
        public int AllowableClass { get; set; }
        public int AllowableRace { get; set; }
        public uint RequiredSpell { get; set; }
        public uint MaxCount { get; set; }
        public uint Stackable { get; set; }
        public int[] ItemStatAllocation { get; set; } // 10
        public float[] ItemStatSocketCostMultiplier { get; set; } // 10
        public float RangedModRange { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Description { get; set; }
        public uint BagFamily { get; set; }
        public float ArmorDamageModifier { get; set; }
        public uint Duration { get; set; }
        public float StatScalingFactor { get; set; }
        public ushort ItemLevel { get; set; }
        public ushort RequiredSkill { get; set; }
        public ushort RequiredSkillRank { get; set; }
        public ushort RequiredReputationFaction { get; set; }
        public short[] ItemStatValue { get; set; } // 10
        public ushort ScalingStatDistribution { get; set; }
        public ushort Delay { get; set; }
        public ushort PageText { get; set; }
        public ushort StartQuest { get; set; }
        public ushort LockId { get; set; }
        public ushort RandomProperty { get; set; }
        public ushort RandomSuffix { get; set; }
        public ushort ItemSet { get; set; }
        public ushort Area { get; set; }
        public ushort Map { get; set; }
        public ushort SocketBonus { get; set; }
        public ushort GemProperties { get; set; }
        public ushort ItemLimitCategory { get; set; }
        public ushort HolidayId { get; set; }
        public ushort ItemNameDescriptionId { get; set; }
        public byte Quality { get; set; }
        public byte BuyCount { get; set; }
        public byte InventoryType { get; set; }
        public sbyte RequiredLevel { get; set; }
        public byte RequiredHonorRank { get; set; }
        public byte RequiredCityRank { get; set; }
        public byte RequiredReputationRank { get; set; }
        public byte ContainerSlots { get; set; }
        public sbyte[] ItemStatType { get; set; } // 10
        public byte DamageType { get; set; }
        public byte Bonding { get; set; }
        public byte LanguageId { get; set; }
        public byte PageMaterial { get; set; }
        public sbyte Material { get; set; }
        public byte Sheath { get; set; }
        public byte TotemCategory { get; set; }
        public byte[] SocketColor { get; set; } // 3
        public byte CurrencySubstitutionId { get; set; }
        public byte CurrencySubstitutionCount { get; set; }
        public byte ArtifactId { get; set; }
        public byte RequiredExpansion { get; set; }

        public Item()
        {
            Flags = new uint[3];
            ItemStatAllocation = new int[10];
            ItemStatSocketCostMultiplier = new float[10];
            ItemStatValue = new short[10];
            ItemStatType = new sbyte[10];
            SocketColor = new byte[3];
        }

        public void ReadObject(IWowClientDBReader dbReader, BinaryReader reader, IDBCDataProvider dbcDataProvider, IDBDataProvider dbDataProvider)
        {
            Id = reader.ReadUInt32();
            for (int i = 0; i < 3; i++)
                Flags[i] = reader.ReadUInt32();
            Unk1 = reader.ReadSingle();
            Unk2 = reader.ReadSingle();
            BuyPrice = reader.ReadUInt32();
            SellPrice = reader.ReadUInt32();
            AllowableClass = reader.ReadInt32();
            AllowableRace = reader.ReadInt32();
            RequiredSpell = reader.ReadUInt32();
            MaxCount = reader.ReadUInt32();
            Stackable = reader.ReadUInt32();
            for (int i = 0; i < 10; i++)
                ItemStatAllocation[i] = reader.ReadInt32();
            for (int i = 0; i < 10; i++)
                ItemStatSocketCostMultiplier[i] = reader.ReadSingle();
            RangedModRange = reader.ReadSingle();

            if (dbReader.HasInlineStrings)
            {
                Name = reader.ReadStringNull();
                Name2 = reader.ReadStringNull();
                Name3 = reader.ReadStringNull();
                Name4 = reader.ReadStringNull();
                Description = reader.ReadStringNull();
            }
            else if (dbReader is STLReader)
            {
                Name = (dbReader as STLReader).ReadString(reader.ReadInt32());
                Name2 = (dbReader as STLReader).ReadString(reader.ReadInt32());
                Name3 = (dbReader as STLReader).ReadString(reader.ReadInt32());
                Name4 = (dbReader as STLReader).ReadString(reader.ReadInt32());
                Description = (dbReader as STLReader).ReadString(reader.ReadInt32());
            }
            else
            {
                Name = dbReader.StringTable[reader.ReadInt32()];
                Name2 = dbReader.StringTable[reader.ReadInt32()];
                Name3 = dbReader.StringTable[reader.ReadInt32()];
                Name4 = dbReader.StringTable[reader.ReadInt32()];
                Description = dbReader.StringTable[reader.ReadInt32()];
            }

            BagFamily = reader.ReadUInt32();
            ArmorDamageModifier = reader.ReadSingle();
            Duration = reader.ReadUInt32();
            StatScalingFactor = reader.ReadSingle();
            ItemLevel = reader.ReadUInt16();
            RequiredSkill = reader.ReadUInt16();
            RequiredReputationFaction = reader.ReadUInt16();
            for (int i = 0; i < 10; i++)
                ItemStatValue[i] = reader.ReadInt16();
            ScalingStatDistribution = reader.ReadUInt16();
            Delay = reader.ReadUInt16();
            PageText = reader.ReadUInt16();
            StartQuest = reader.ReadUInt16();
            LockId = reader.ReadUInt16();
            RandomProperty = reader.ReadUInt16();
            RandomSuffix = reader.ReadUInt16();
            ItemSet = reader.ReadUInt16();
            Area = reader.ReadUInt16();
            Map = reader.ReadUInt16();
            SocketBonus = reader.ReadUInt16();
            GemProperties = reader.ReadUInt16();
            ItemLimitCategory = reader.ReadUInt16();
            HolidayId = reader.ReadUInt16();
            ItemNameDescriptionId = reader.ReadUInt16();
            Quality = reader.ReadByte();
            BuyCount = reader.ReadByte();
            InventoryType = reader.ReadByte();
            RequiredLevel = reader.ReadSByte();
            RequiredHonorRank = reader.ReadByte();
            RequiredCityRank = reader.ReadByte();
            RequiredReputationRank = reader.ReadByte();
            ContainerSlots = reader.ReadByte();
            for (int i = 0; i < 10; i++)
                ItemStatType[i] = reader.ReadSByte();
            DamageType = reader.ReadByte();
            Bonding = reader.ReadByte();
            LanguageId = reader.ReadByte();
            PageMaterial = reader.ReadByte();
            Material = reader.ReadSByte();
            Sheath = reader.ReadByte();
            TotemCategory = reader.ReadByte();
            for (int i = 0; i < 3; i++)
                SocketColor[i] = reader.ReadByte();
            CurrencySubstitutionId = reader.ReadByte();
            CurrencySubstitutionCount = reader.ReadByte();
            ArtifactId = reader.ReadByte();
            RequiredExpansion = reader.ReadByte();
        }
    }
}
