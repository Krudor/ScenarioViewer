using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioViewer.Utils.Misc
{
    public class WowheadUtils
    {
        public static List<string> WowheadLocaleMapper = new List<string>
        {
            "de",
            "es",
            "fr",
            "it",
            "pt",
            "ru",
            "ko",
            "cn"
        };

        public static string GetWowheadURL() => GetWowheadURL(CultureInfo.CurrentCulture, false);

        public static string GetWowheadURL(CultureInfo culture, bool forceUseCulture)
        {
            CultureInfo currentCulture = culture ?? CultureInfo.CurrentCulture;
            string domain = "www";
            if (forceUseCulture || WowheadLocaleMapper.Contains(currentCulture.TwoLetterISOLanguageName))
                domain = currentCulture.TwoLetterISOLanguageName;

            return $"{domain}.wowhead.com";
        }

        public static string GetWowheadDataSectionUrl(WowheadDataSection section, uint value) => Path.Combine(GetWowheadURL(), $"{section.ToString().ToLower()}={value}");

        public static string GetWowheadURLForSpell(uint spellId)
            => GetWowheadDataSectionUrl(WowheadDataSection.Spell, spellId);

        public static string GetWowheadURLForCreature(uint creatureId)
            => GetWowheadDataSectionUrl(WowheadDataSection.Npc, creatureId);

        public static string GetWowheadURLForQuest(uint questId)
            => GetWowheadDataSectionUrl(WowheadDataSection.Quest, questId);

        public static string GetWowheadURLForAchievement(uint achievementId)
            => GetWowheadDataSectionUrl(WowheadDataSection.Achievement, achievementId);

        public static string GetWowheadURLForItem(uint itemId)
            => GetWowheadDataSectionUrl(WowheadDataSection.Item, itemId);

        public static string GetWowheadURLForGameobject(uint gameobjectId)
            => GetWowheadDataSectionUrl(WowheadDataSection.Gameobject, gameobjectId);
    }

    public enum WowheadDataSection
    {
        Spell,
        Npc,
        Quest,
        Achievement,
        Item,
        Gameobject
    }
}
