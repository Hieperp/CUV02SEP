﻿using System;
using System.Configuration;

namespace TotalSmartCoding.Libraries
{
    public class CommonConfigs
    {
        public static string ReadConnectionString(string name)
        {
            try
            {
                var appSettings = ConfigurationManager.ConnectionStrings;
                for (int i = 0; i <= appSettings.Count - 1; i++)
                {
                    if (appSettings[i].Name == name) return appSettings[i].ConnectionString;
                }

                return "";
            }
            catch (ConfigurationErrorsException e)
            {
                throw e;
            }
        }

        public static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key] ?? "";
            }
            catch (ConfigurationErrorsException e)
            {
                throw e;
            }
        }

        public static void AddUpdateAppSetting(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
