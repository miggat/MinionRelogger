using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Helpers.Language.Languages
{
    public class English : Language
    {
        public English()
        {
            // class: BreakObject
            Translations.Add(ETranslations.BreakObjectExpired, "Break has expired for {0}, starting new cycle!");
            Translations.Add(ETranslations.BreakObjectNew, "New Start Break: {0}, New End Break: {1}.");

            // class: Config
            Translations.Add(ETranslations.ConfigNewAccount, "Added new Account object.");

            // class: DataProtector
            Translations.Add(ETranslations.DataProtectorErrorOccured, "An error has occurred during data encryption!");
            Translations.Add(ETranslations.DataProtectorDeletedSaveFile, "Old save file has been deleted, must have been a different version or corrupt!");

            // class: General Settings
            Translations.Add(ETranslations.GeneralSettingsGW2PathChanged, "GW2 Path has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsPollingDelayChanged, "Polling delay has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsLaunchDelayChanged, "Launch delay has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsRestartDelayChanged, "Restart delay has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsColorChanged, "Switched to color: {0}.");
            Translations.Add(ETranslations.GeneralSettingsThemeChanged, "Switched to theme: {0}.");
            Translations.Add(ETranslations.GeneralSettingsMinimizeWindowsChanged, "Minimize windows has been changed to: {0}.");
            Translations.Add(ETranslations.GeneralSettingsCheckForIPChanged,
                             "Check for IP has been changed to: {0}.");
            Translations.Add(ETranslations.GeneralSettingsAddedIP, "Added IP address {0} to the list of allowed addresses.");
            Translations.Add(ETranslations.GeneralSettingsDeletedIP, "Deleted IP address {0} from the list of allowed addresses.");

            // class: InputBox
            Translations.Add(ETranslations.InputBoxOk, "OK");
            Translations.Add(ETranslations.InputBoxCancel, "Cancel");

            // class: KillWorker
            Translations.Add(ETranslations.KillWorkerStoppingProcess, "Stopping process with PID {0}.");

            // class: StartWorker
            Translations.Add(ETranslations.StartWorkerLaunchingInstance, "Launching instance for {0} with {1}.");
            Translations.Add(ETranslations.StartWorkerScanningForExisting, "Stopping process with PID {0}.");
            Translations.Add(ETranslations.StartWorkerFoundWantedProcess, "Found wanted process for {0}, no need to launch.");
            Translations.Add(ETranslations.StartWorkerAttachingTo, "Attaching to {0} with {1}.");

            // class: WatchObject
            Translations.Add(ETranslations.WatchObjectNotRespondingFor, "The GW 2 instance, running {0}, has not been responding for 90 seconds, restarting it.");
        }

        public override string GetLanguageDescription()
        {
            return "English";
        }

        public override ELanguages GetLanguage()
        {
            return ELanguages.English;
        }
    }
}
