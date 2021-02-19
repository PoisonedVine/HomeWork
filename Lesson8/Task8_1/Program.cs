using System;
using System.Configuration;


namespace Task8_1
{
    class Program
    {
        static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return (appSettings[key] ?? String.Empty);
            }
            catch (Exception)
            {
                //Console.WriteLine($"Error reading app settings. Key = {key}");
                return (String.Empty);
            }
        }
        static void AddUpdateAppSettings(string key, string value)
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
            catch (Exception ex)
            {
                Console.WriteLine("Error writing app settings: {2} Key: {0} Value: {1}", key, value, ex.Message);
            }
        }

        static void Main(string[] args)
        {
            const string GreetingAttr = "Greetings";

            if (String.IsNullOrEmpty(ReadSetting(GreetingAttr))) {
                AddUpdateAppSettings(GreetingAttr, "Hello World");   
            }

            Console.WriteLine(ReadSetting(GreetingAttr));

            string UserName = ReadSetting("UserName");
            string Age = ReadSetting("Age");
            string Occupation = ReadSetting("Occupation");

            if (!String.IsNullOrEmpty(UserName)) {
                Console.WriteLine("{0}:{1}", "UserName", UserName);
            }

            if (!String.IsNullOrEmpty(Age)) {
                Console.WriteLine("{0}:{1}", "Age", Age);
            }

            if (!String.IsNullOrEmpty(Occupation)) {
                Console.WriteLine("{0}:{1}", "Occupation", Occupation);
            }

            Console.WriteLine("\nИзменение настроек\n");

            Console.WriteLine("Введите имя");
            UserName = Console.ReadLine();
            AddUpdateAppSettings("UserName", UserName);


            Console.WriteLine("Введите возраст");
            Age = Console.ReadLine();
            AddUpdateAppSettings("Age", Age);


            Console.WriteLine("Введите род занятий");
            Occupation = Console.ReadLine();
            AddUpdateAppSettings("Occupation", Occupation);           
        }
    }
}
