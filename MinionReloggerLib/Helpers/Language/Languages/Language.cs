using System.Collections.Generic;
using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Helpers.Language.Languages
{
    public abstract class Language
    {
        protected Dictionary<ETranslations, string> Translations;

        public Language()
        {
            Translations = new Dictionary<ETranslations, string>();
        }

        public string GetTranslation(ETranslations key)
        {
            return Translations[key];
        }

        public abstract string GetLanguageDescription();

        public abstract ELanguages GetLanguage();
    }
}
