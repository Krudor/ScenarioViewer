using System.ComponentModel;

namespace ScenarioViewer.Model
{
    public enum CriteriaType : byte
    {
        [Description("Kill creature")]
        KillCreature                        = 0,

        [Description("Win battleground")]
        WinBattleground                     = 1,

        // 2 - 0 criterias
        
        [Description("Complete archeology projects")]
        CompleteArcheologyProjects          = 3,

        [NYI]
        [Description("Survey gameobject")]
        SurveyGameobject                    = 4, // With "Luron" present only? http://www.wowhead.com/npc=103733/luron

        [Description("Reach level")]
        ReachLevel                          = 5,

        [NYI]
        [Description("Clear digsite")]
        ClearDigsite                        = 6,

        [Description("Reach skill level")]
        ReachSkillLevel                     = 7,

        [Description("Complete achievement")]
        CompleteAchievement                 = 8,

        [Description("Complete quest count")]
        CompleteQuestCount                  = 9,

        [Description("Complete daily quest daily")]
        CompleteDailyQuestDaily             = 10,

        [Description("Complete quests in zone")]
        CompleteQuestsInZone                = 11,

        [Description("Receive currency")]
        Currency                            = 12,

        [Description("Damage done")]
        DamageDone                          = 13,

        [Description("Complete daily quest")]
        CompleteDailyQuest                  = 14,

        [Description("Win battleground")]
        CompleteBattleground                = 15,

        [Description("Death at map")]
        DeathAtMap                          = 16,

        [Description("Deaths")]
        Death                               = 17,

        [Description("Deaths in dungeons")]
        DeathInDungeon                      = 18,

        [Description("Complete raid")]
        CompleteRaid                        = 19,

        [Description("Killed by creature")]
        KilledByCreature                    = 20,

        [NYI]
        [Description("Granted criteria")]
        ManuallyGivenCriteria               = 21,

        [NYI]
        [Description("Guild - Complete challenge mode")]
        GuildCompleteChallengeMode          = 22,

        [Description("Killed by players")]
        KilledByPlayer                      = 23,

        [Description("Fall without dying")]
        FallWithoutDying                    = 24,

        [Description("Deaths by damage type")]
        DeathsFrom                          = 26,

        [Description("Complete Quest")]
        CompleteQuest                       = 27,

        [Description("Be target of spell")]
        BeSpellTarget                       = 28,

        [Description("Cast spell")]
        CastSpell                           = 29,

        [Description("Capture battleground objective")]
        BattlegroundObjectiveCapture        = 30,

        [Description("Earn honorable kill at area")]
        HonorableKillAtArea                 = 31,

        [Description("Win arena")]
        WinArena                            = 32,

        [Description("Play arena")]
        PlayArena                           = 33,

        [Description("Learn spell")]
        LearnSpell                          = 34,

        [Description("Earn honorable kill")]
        HonorableKill                       = 35,

        [Description("Own item")]
        OwnItem                             = 36,

        [Description("Win rated arena")]
        WinRatedArena                       = 37,

        [Description("Highest team rating")]
        HighestTeamRating                   = 38,

        [Description("Highest personal rating")]
        HighestPersonalRating               = 39,

        [Description("Learn skill level")]
        LearnSkillLevel                     = 40,

        [Description("Use item")]
        UseItem                             = 41,

        [Description("Loot item")]
        LootItem                            = 42,

        [Description("Explore area")]
        ExploreArea                         = 43,

        [Description("Own rank")]
        OwnRank                             = 44,

        [Description("Buy bank slot")]
        BuyBankSlot                         = 45,

        [Description("Gain reputation")]
        GainReputation                      = 46,

        [Description("Gain exalted reputation")]
        GainExaltedReputation               = 47,

        [Description("Visit barber shop")]
        VisitBarberShop                     = 48,

        [Description("Equip epic item")]
        EquipEpicItem                       = 49,

        [Description("Roll need on loot")]
        RollNeedOnLoot                      = 50,

        [Description("Roll greed on loot")]
        RollGreedOnLoot                     = 51,

        [Description("Killed player of class")]
        HonorableKillClass                  = 52,

        [Description("Killed player of race")]
        HonorableKillRace                   = 53,

        [Description("Do emote")]
        DoEmote                             = 54,

        [Description("Healing done")]
        HealingDone                         = 55,

        [Description("Killing blows")]
        GetKillingBlows                     = 56,

        [Description("Equip item")]
        EquipItem                           = 57,

        // 58 - 0 criterias

        [Description("Money from vendors")]
        MoneyFromVendors                    = 59,

        [Description("Gold spent for talents")]
        GoldSpentForTalents                 = 60,

        [Description("Number of talent resets")]
        NumberOfTalentResets                = 61,

        [Description("Money from quest rewards")]
        MoneyFromQuestReward                = 62,

        [Description("Gold spent on traveling")]
        GoldSpentOnTraveling                = 63,

        [NYI]
        [Description("Defeat creature group")]
        DefeatCreatureGroup                 = 64,

        [Description("Gold spent at barber")]
        GoldSpentAtBarber                   = 65,

        [Description("Gold spent on mailing")]
        GoldSpentOnMailing                  = 66,

        [Description("Loot money")]
        LootMoney                           = 67,

        [Description("Use gameobject")]
        UseGameobject                       = 68,

        [Description("Be spell target 2")]
        BeSpellTarget2                      = 69,

        [Description("Special PVP kill")]
        SpecialPvpKill                      = 70,

        [NYI]
        [Description("Complete challenge mode")]
        CompleteChallengeMode               = 71,

        [Description("Fish in gameobject")]
        FishInGameobject                    = 72,

        [NYI]
        [Description("Send event")]
        SendEvent                           = 73,

        [Description("On login")]
        OnLogin                             = 74,

        [Description("Learn skill line spells")]
        LearnSkillLineSpells                = 75,

        [Description("Win duel")]
        WinDuel                             = 76,

        [Description("Lose duel")]
        LoseDuel                            = 77,

        [Description("Kill creature of type")]
        KillCreatureType                    = 78,

        [NYI]
        [Description("Guild - Cook recipes")]
        GuildCookRecipes                    = 79,

        [Description("Gold earned from auctions")]
        GoldEarnedFromAuctions              = 80,

        [NYI]
        [Description("Earn pet battle achievement points")]
        EarnPetBattleAchievementPoints      = 81,

        [Description("Create auction")]
        CreateAuction                       = 82,

        [Description("Highest auction bid")]
        HighestAuctionBid                   = 83,

        [Description("Won auctions")]
        WonAuctions                         = 84,

        [Description("Highest auction sold")]
        HighestAuctionSold                  = 85,

        [Description("Highest gold value owned")]
        HighestGoldValueOwned               = 86,

        [Description("Gain revered reputation")]
        GainReveredReputation               = 87,

        [Description("Gain honored reputation")]
        GainHonoredReputation               = 88,

        [Description("Known factions")]
        KnownFactions                       = 89,

        [Description("Loot epic item")]
        LootEpicItem                        = 90,

        [Description("Receive epic item")]
        ReceiveEpicItem                     = 91,

        [NYI]
        [Description("Send event to scenario")]
        SendEventScenario                   = 92,

        [Description("Roll need")]
        RollNeed                            = 93,

        [Description("Roll greed")]
        RollGreed                           = 94,

        [NYI]
        [Description("Release spirit")]
        ReleaseSpirit                       = 95,

        [NYI]
        [Description("Own pet")]
        OwnPet                              = 96,

        [NYI]
        [Description("Dungeon encounter complete (Garrison tracking)")]
        DungeonEncounterCompleteGarrisonTracker = 97,

        // 98 - 0 criterias

        // 99 - 0 criterias

        // 100 - 0 criterias

        [Description("Highest hit dealt")]
        HighestHitDealt                     = 101,

        [Description("Highest hit received")]
        HighestHitReceived                  = 102,

        [Description("Total damage received")]
        TotalDamageReceived                 = 103,

        [Description("Highest heal cast")]
        HighestHealCast                     = 104,

        [Description("Total healing received")]
        TotalHealingReceived                = 105,

        [Description("Highest healing received")]
        HighestHealingReceived              = 106,

        [Description("Quest abandoned")]
        QuestAbandoned                      = 107,

        [Description("Flight paths taken")]
        FlightPathsTaken                    = 108,

        [Description("Loot type")]
        LootType                            = 109,

        [Description("Cast spell 2")]
        CastSpell2                          = 110,

        // 111 - 0 criterias
        [Description("Learn skill line")]
        LearnSkillLine                      = 112,

        [Description("Earn honorable kill")]
        EarnHonorableKill                   = 113,

        [Description("Accepted summons")]
        AcceptedSummons                     = 114,

        [Description("Earned achievement points")]
        EarnedAchievementPoints             = 115,

        // 116 - 0 criterias

        // 117 - 0 criterias

        [Description("Complete LFG dungeon - statistics")]
        CompleteLFGDungeon                  = 118,

        [Description("Used Looking for Dungeon to group with players")]
        UseLFDToGroupWithPlayers            = 119,

        [NYI]
        [Description("Successfully kick player from LFG after initiating vote")]
        KickPlayerFromLFG                   = 120,

        [NYI]
        [Description("Successfully kick player from LFG after agreeing vote")]
        KickPlayerFromLFGAgreed             = 121,

        [NYI]
        [Description("Kicked in LFG")]
        KickedInLFG                         = 122,

        [NYI]
        [Description("Abandon LFG")]
        AbandonLFG                          = 123,

        [Description("Guild - Gold spent on repairs")]
        SpentGoldGuildRepairs               = 124,

        [Description("Guild - Reach level")]
        ReachGuildLevel                     = 125,

        [Description("Guild - Craft items")]
        CraftItemsGuild                     = 126,

        [Description("Catch from pool")]
        CatchFromPool                       = 127,

        [Description("Guild - Buy bank slots")]
        BuyGuildBankSlots                   = 128,

        [Description("Guild - Earn achievement points")]
        EarnGuildAchievementPoints          = 129,

        [Description("Win rated battleground")]
        WinRatedBattleground                = 130,

        // 131 - 0 criterias

        [Description("Reach rated battleground rating")]
        ReachRatedBGRating                  = 132,

        [Description("Buy guild tabard")]
        BuyGuildTabard                      = 133,

        [Description("Guild - Complete quests")]
        CompleteQuestsGuild                 = 134,

        [Description("Guild - Honorable kills")]
        HonorableKillsGuild                 = 135,

        [Description("Guild - Kill creature of type")]
        KillCreatureTypeGuild               = 136,

        [NYI]
        [Description("In LFG group where tank leaves early")]
        LFGTankLeavesGroupEarly             = 137,

        [Description("Guild - Complete challenge type")]
        CompleteGuildChallengeType          = 138,

        [Description("Guild - Complete challenge")]
        CompleteGuildChallenge              = 139,

        // 140 - 1 criteria, appears unused

        // 141 - 1 criteria, appears unused

        // 142 - 1 criteria, appears unused

        // 143 - 1 criteria, appears unused

        // 144 - 1 criteria, appears unused

        [Description("Looking for raid - Dungeons completed")]
        LFRDungeonsCompleted                = 145,

        [Description("Looking for raid - Leaves")]
        LFRLeaves                           = 146,

        [Description("Looking for raid - Vote to kick initiated")]
        LFRVoteKicksInitiatedByPlayer       = 147,

        [Description("Looking for raid - Vote to kick not initiated")]
        LFRVoteKicksNotInitiatedByPlayer    = 148,

        [Description("Looking for raid - Get kicked")]
        BeKickedFromLFR                     = 149,

        [Description("Looking for raid - Queue boosts by tank")]
        CountOfLFRQueueBoostsByTank         = 150,

        [Description("Complete scenario count")]
        CompleteScenarioCount               = 151,

        [Description("Complete scenario")]
        CompleteScenario                    = 152,

        [Description("Reach areatrigger")]
        ReachAreatrigger                    = 153,

        // 154 - 0 criterias

        [Description("Own battle pet")]
        OwnBattlePet                        = 155,

        [Description("Own battle pet count")]
        OwnBattlePetCount                   = 156,

        [Description("Capture battle pet")]
        CaptureBattlePet                    = 157,

        [Description("Win pet battle")]
        WinPetBattle                        = 158,

        // 159 - 0 criterias

        [Description("Level battle pet")]
        LevelBattlePet                      = 160,

        [Description("Capture battle pet credit")]
        CaptureBattlePetCredit              = 161,

        [Description("Level battle pet credit")]
        LevelPetBattleCredit                = 162,

        [Description("Enter area")]
        EnterArea                           = 163,

        [Description("Leave area")]
        LeaveArea                           = 164,

        [Description("Complete dungeon encounter")]
        CompleteDungeonEncounter            = 165,

        // 166 - 0 criterias

        [Description("Garrison - Place building")]
        PlaceGarrisonBuilding               = 167,

        [Description("Garrison - Upgrade building")]
        UpgradeGarrisonBuilding             = 168,

        [Description("Garrison - Construct building")]
        ConstructGarrisonBuilding           = 169,

        [Description("Garrison - Upgrade garrison")]
        UpgradeGarrison                     = 170,

        [Description("Garrison - Start mission")]
        StartGarrisonMission                = 171,

        [Description("Order hall - Start mission")]
        StartOrderHallMission               = 172,

        [Description("Garrison - Completed mission count")]
        CompleteGarrisonMissionCount        = 173,

        [Description("Garrison - Complete mission")]
        CompleteGarrisonMission             = 174,

        [Description("Garrison - Recruit follower count")]
        RecruitGarrisonFollowerCount        = 175,

        [Description("Garrison - Recruit follower")]
        RecruitGarrisonFollower             = 176,

        // 177 - 0 criterias

        [Description("Garrison - Learn blueprint count")]
        LearnGarrisonBlueprintCount         = 178,

        // 179 - 0 criterias

        // 180 - 0 criterias

        // 181 - 0 criterias

        [Description("Garrison - Complete shipment")]
        CompleteGarrisonShipment            = 182,

        [Description("Garrison - Raise follower itemlevel")]
        RaiseGarrisonFollowerItemLevel      = 183,

        [Description("Garrison - Raise follower level")]
        RaiseGarrisonFollowerLevel          = 184,

        [Description("Own toy")]
        OwnToy                              = 185,

        [Description("Own toy count")]
        OwnToyCount                         = 186,

        [Description("Garrison - Recruit follower with quality")]
        RecruitGarrisonFollowerQuality      = 187,

        // 188 - 0 criterias

        [Description("Own heirlooms")]
        OwnHeirlooms                        = 189,

        [Description("Artifact power earned")]
        ArtifactPowerEarned                 = 190,

        [Description("Artifact traits unlocked")]
        ArtifactTraitsUnlocked              = 191,

        [Description("Reached honor level")]
        HonorLevelReached                   = 194,
        
        [Description("Reached prestige")]
        PrestigeReached                     = 195,
        
        [Description("Order Hall talent learned")]
        OrderHallTalentLearned              = 198,

        [Description("Appearance unlocked by slot")]
        AppearanceUnlockedBySlot            = 199,

        [Description("Order Hall recruit troop")]
        OrderHallRecruitTroop               = 200,

        [Description("Complete world quest")]
        CompleteWorldQuest                  = 203,
    }
}