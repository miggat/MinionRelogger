using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Helpers.Encryption
{
    internal static class DataProtector
    {
        private const string EntropyValue = "ThisStringIsNotSoSecretRight";

        internal static string EncryptData(string stringToEncrypt)
        {
            var encryptedData = new byte[] {};
            try
            {
                encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(stringToEncrypt),
                                                      Encoding.Unicode.GetBytes(EntropyValue),
                                                      DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException ex)
            {
                Logger.LoggingObject.Log(ELogType.Critical, LanguageManager.Singleton.GetTranslation(ETranslations.DataProtectorErrorOccured));
                Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                Logger.LoggingObject.Log(ELogType.Critical,
                                         LanguageManager.Singleton.GetTranslation(ETranslations.DataProtectorDeletedSaveFile));
                try
                {
                    File.Delete("Launcher.bin");
                }
                catch (UnauthorizedAccessException ex2)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                }
                catch (IOException ex3)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                }
            }
            return Convert.ToBase64String(encryptedData);
        }

        internal static string DecryptData(string stringToDecrypt)
        {
            var decryptedData = new byte[] {};
            try
            {
                decryptedData = ProtectedData.Unprotect(Convert.FromBase64String(stringToDecrypt),
                                                        Encoding.Unicode.GetBytes(EntropyValue),
                                                        DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException ex)
            {
                Logger.LoggingObject.Log(ELogType.Critical, LanguageManager.Singleton.GetTranslation(ETranslations.DataProtectorErrorOccured));
                Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                Logger.LoggingObject.Log(ELogType.Critical,
                                         LanguageManager.Singleton.GetTranslation(ETranslations.DataProtectorDeletedSaveFile));
                try
                {
                    File.Delete("" +
                                "Launcher.bin");
                }
                catch (UnauthorizedAccessException ex2)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                }
                catch (IOException ex3)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                }
            }
            return Encoding.Unicode.GetString(decryptedData);
        }
    }
}