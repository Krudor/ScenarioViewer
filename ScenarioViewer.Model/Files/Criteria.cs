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
    public class Criteria : IDBObjectReader
    {
        public const string FileName = @"Criteria.db2";

        public uint Id { get; set; }
        public uint Asset { get; set; }
        public uint StartAsset { get; set; }
        public uint FailAsset { get; set; }
        public ushort StartTimer { get; set; }
        public ushort ModifierTreeId { get; set; }
        public ushort EligibilityWorldStateId { get; set; }
        public CriteriaType Type { get; set; }
        public byte StartEvent { get; set; }
        public CriteriaCondition FailEvent { get; set; }
        public byte Flags { get; set; }
        public byte EligibilityWorldStateValue { get; set; }
        public string AssetCustomValue { get; set; }

        private IDBCDataProvider _dbcDataProvider;
        private IDBDataProvider _dbDataProvider;
        
        public string ToString(bool verbose, CriteriaTree parent)
        {
            string text = "";
            switch (Type)
            {
                case CriteriaType.KillCreature:
                {
                    string name = _dbDataProvider.GetCreatureName(Asset);
                    if (!string.IsNullOrEmpty(name))
                        text = $"Kill \"{name}\" (entry: {Asset})";
                    else
                        text = $"Kill creature with entry \"{Asset}\"";
                    break;
                }
                case CriteriaType.ManuallyGivenCriteria:
                    text = $"Get manually granted the criteria (id: {Id})";
                    break;
                case CriteriaType.BeSpellTarget:
                {
                    Spell spell = _dbcDataProvider.GetSpell(Asset);
                    if (!string.IsNullOrEmpty(spell?.Name))
                        text = $"Be target of spell \"{spell.Name}\" (id: {Asset})";
                    else
                        text = $"Be target of spell (id: {Asset})";
                    break;
                }
                case CriteriaType.CastSpell:
                {
                    Spell spell = _dbcDataProvider.GetSpell(Asset);
                    if (!string.IsNullOrEmpty(spell?.Name))
                        text = $"Cast spell \"{spell.Name}\" (id: {Asset})";
                    else
                        text = $"Cast spell (id: {Asset})";
                        break;
                }
                case CriteriaType.DefeatCreatureGroup:
                    text = $"Defeat creature group (id: {Asset})";
                    break;
                case CriteriaType.SendEvent:
                    text = $"Event \"{Asset}\" is sent";
                    break;
                case CriteriaType.SendEventScenario:
                    text = $"Event \"{Asset}\" is sent to scenario";
                    break;
                case CriteriaType.CastSpell2:
                {
                    Spell spell = _dbcDataProvider.GetSpell(Asset);
                    if (!string.IsNullOrEmpty(spell?.Name))
                        text = $"Hit a target with spell \"{spell.Name}\" (id: {Asset})";
                    else
                        text = $"Hit a target with spell (id: {Asset})";
                    break;
                }
                case CriteriaType.LootItem:
                {
                    Item item = _dbcDataProvider.GetItem(Asset);
                    if (!string.IsNullOrEmpty(item?.Name))
                        text = $"Loot \"{item.Name}\" ({Asset})";
                    else
                        text = $"Loot item with id \"{Asset}\"";
                    break;
                }
                case CriteriaType.OwnItem:
                {
                    Item item = _dbcDataProvider.GetItem(Asset);
                    if (!string.IsNullOrEmpty(item?.Name))
                        text = $"Own item \"{item.Name}\" ({Asset})";
                    else
                        text = $"Own item with id \"{Asset}\"";
                    break;
                }
                case CriteriaType.ReachAreatrigger:
                    text = $"Reach areatrigger using ActionSet id \"{Asset}\"";
                    break;
                case CriteriaType.CompleteDungeonEncounter:
                    DungeonEncounter dungeonEncounter = _dbcDataProvider.GetDungeonEncounter(Asset);
                    if (!string.IsNullOrEmpty(dungeonEncounter?.Name))
                        text = $"Complete the {dungeonEncounter.Name} ({Asset}) dungeon encounter";
                    else
                        text = $"Complete dungeon encounter \"{Asset}\"";
                    break;
                case CriteriaType.UseGameobject:
                {
                    string name = _dbDataProvider.GetGameobjectName(Asset);
                    if (!string.IsNullOrEmpty(name))
                        text = $"Use \"{name}\" (entry: \"{Asset}\")";
                    else
                        text = $"Use gameobject with entry \"{Asset}\"";
                    break;
                }
                default:
                    break;
            }

            if (string.IsNullOrEmpty(text))
                text = !Enum.IsDefined(typeof(CriteriaType), Type)
                    ? $" - (Unknown criteria type: \"{Type}\", data: {Asset})"
                    : $" - Unspecified criteria type \"{Enum.GetName(typeof(CriteriaType), Type)}\", data: {Asset}";

            if (verbose)
                text = $"C {Id} - {text}";

            if (parent.Parent != null && parent.Parent.Operator == CriteriaTreeOperator.SumChildrenWeight)
                text = $"{text}, progress {parent.Amount}";

            if (Type.NotYetImplemented())
                text += " (NYI)";

            return text;
        }

        public void ReadObject(IWowClientDBReader dbReader, BinaryReader binaryReader, IDBCDataProvider dbcDataProvider, IDBDataProvider dbDataProvider)
        {
            _dbcDataProvider = dbcDataProvider;
            _dbDataProvider = dbDataProvider;

            using (BinaryReader br = binaryReader)
            {
                Id = br.ReadUInt32();

                Asset = br.ReadUInt32();
                StartAsset = br.ReadUInt32();
                FailAsset = br.ReadUInt32();
                StartTimer = br.ReadUInt16();
                ModifierTreeId = br.ReadUInt16();
                EligibilityWorldStateId = br.ReadUInt16();
                Type = (CriteriaType)br.ReadByte();
                StartEvent = br.ReadByte();
                FailEvent = (CriteriaCondition)br.ReadByte();
                Flags = br.ReadByte();
                EligibilityWorldStateValue = br.ReadByte();
            }
        }
    }

    public enum CriteriaCondition : byte
    {
        None            = 0,
        NoDeath         = 1,
        Unk2            = 2,
        BGMap           = 3,
        NoLose          = 4,
        Unk5            = 5,
        Unk8            = 8,
        NoSpellHit      = 9,
        NotInGroup      = 10,
        Unk13           = 13
    };

    public enum CriteriaAdditionalCondition
    {
        SourceDrunkValue = 1, // NYI
        Unk2 = 2,
        ItemLevel = 3, // NYI
        TargetCreatureEntry = 4,
        TargetMustBePlayer = 5,
        TargetMustBeDead = 6,
        TargetMustBeEnemy = 7,
        SourceHasAura = 8,
        TargetHasAura = 10,
        TargetHasAuraType = 11,
        ItemQualityMin = 14,
        ItemQualityEquals = 15,
        Unk16 = 16,
        SourceAreaOrZone = 17,
        TargetAreaOrZone = 18,
        MaxDifficulty = 20,
        TargetCreatureYieldsExperience = 21, // NYI
        ArenaType = 24,
        SourceRace = 25,
        SourceClass = 26,
        TargetRace = 27,
        TargetClass = 28,
        MaxGroupMembers = 29,
        TargetCreatureType = 30,
        SourceMap = 32,
        ItemClass = 33, // NYI
        ItemSubClass = 34, // NYI
        CompleteQuestNotInGroup = 35, // NYI
        MinPersonalRating = 37, // NYI (when implementing don't forget about CRITERIA_CONDITION_NO_LOSE)
        TitleBitIndex = 38,
        SourceLevel = 39,
        TargetLevel = 40,
        TargetZone = 41,
        TargetHealthPercentageBelow = 46,
        Unk55 = 55,
        MinAchievementPoints = 56, // NYI
        RequiresLFGGroup = 58, // NYI
        Unk60 = 60,
        RequiresGuildGroup = 61, // NYI
        GuildReputation = 62, // NYI
        RatedBattleground = 63, // NYI
        ProjectRarity = 65,
        ProjectRace = 66,
        BattlePetSpecies = 91,
        GarrisonFollowerQuality = 145,
        GarrisonFollowerLevel = 146,
        GarrisonRareMission = 147, // NYI
        GarrisonBuildingLevel = 149, // NYI
        GarrisonMissionType = 167, // NYI
        GarrisonFollowerItemlevel = 184,
    };

    public enum CriteriaFlags
    {
        CRITERIA_FLAG_SHOW_PROGRESS_BAR = 0x00000001,   // Show progress as bar
        CRITERIA_FLAG_HIDDEN = 0x00000002,   // Not show criteria in client
        CRITERIA_FLAG_FAIL_ACHIEVEMENT = 0x00000004,   // BG related??
        CRITERIA_FLAG_RESET_ON_START = 0x00000008,   //
        CRITERIA_FLAG_IS_DATE = 0x00000010,   // not used
        CRITERIA_FLAG_MONEY_COUNTER = 0x00000020    // Displays counter as money
    };

    public enum CriteriaTimedTypes
    {
        CRITERIA_TIMED_TYPE_EVENT = 1,    // Timer is started by internal event with id in timerStartEvent
        CRITERIA_TIMED_TYPE_QUEST = 2,    // Timer is started by accepting quest with entry in timerStartEvent
        CRITERIA_TIMED_TYPE_SPELL_CASTER = 5,    // Timer is started by casting a spell with entry in timerStartEvent
        CRITERIA_TIMED_TYPE_SPELL_TARGET = 6,    // Timer is started by being target of spell with entry in timerStartEvent
        CRITERIA_TIMED_TYPE_CREATURE = 7,    // Timer is started by killing creature with entry in timerStartEvent
        CRITERIA_TIMED_TYPE_ITEM = 9,    // Timer is started by using item with entry in timerStartEvent
        CRITERIA_TIMED_TYPE_UNK = 10,   // Unknown
        CRITERIA_TIMED_TYPE_UNK_2 = 13,   // Unknown
        CRITERIA_TIMED_TYPE_SCENARIO_STAGE = 14,   // Timer is started by changing stages in a scenario

        CRITERIA_TIMED_TYPE_MAX
    };
}
