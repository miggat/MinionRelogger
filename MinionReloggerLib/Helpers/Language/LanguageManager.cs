using System.Collections.Generic;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language.Languages;

namespace MinionReloggerLib.Helpers.Language
{
    public class LanguageManager
    {
        private static LanguageManager _instance;

        private readonly Dictionary<ELanguages, Languages.Language> _languages;
        private ELanguages _currentLanguage;

        protected LanguageManager()
        {
            _languages = new Dictionary<ELanguages, Languages.Language>
                {
                    {ELanguages.English, new English()},

                };
            _currentLanguage = ELanguages.Default;
        }

        public static LanguageManager Singleton
        {
            get { return _instance ?? (_instance = new LanguageManager()); }
            set { _instance = value; }
        }

        public string GetTranslation(ETranslations key)
        {
            return _languages[_currentLanguage].GetTranslation(key);
        }

        public void SetNewLanguage(ELanguages newLanguage)
        {
            _currentLanguage = newLanguage;
        }

        public ELanguages GetCurrentLanguage()
        {
            return _currentLanguage;
        }
    }
}
