using System.Diagnostics;
using static MGS1_MC_Cheat_Trainer.MemoryManager;

namespace MGS1_MC_Cheat_Trainer
{
    internal class LoggingManager
    {
        private static LoggingManager instance;
        private static readonly object padlock = new object();
        private static string logFolderPath;
        private static string logFileName = "MGS1_MC_Cheat_Trainer_Log.txt";
        private static string logPath;

        // Static constructor to initialize logFolderPath and logPath
        static LoggingManager()
        {
            // Use the Documents folder for storing logs, with a specific subfolder for the application
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appLogFolder = "MGS Cheat Trainer Logs"; // Specific name for the log folder

            logFolderPath = Path.Combine(documentsFolder, appLogFolder);
            logPath = Path.Combine(logFolderPath, logFileName);

            EnsureLogFileExists();
        }

        private LoggingManager()
        {

        }

        public static LoggingManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LoggingManager();
                    }

                    return instance;
                }
            }
        }

        private static void EnsureLogFileExists()
        {
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }

            if (!File.Exists(logPath))
            {
                using (var stream = File.Create(logPath))
                {
                }
            }
        }

        public void Log(string message)
        {
            try
            {
                using (var writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while trying to log: {ex.Message}");
            }
        }

        public void LogAllDamageReadings()
        {
            var damageReadings = new Dictionary<string, Func<string>>()
            {

                { "Socom's Current Ammo", () => AobManager.Instance.ReadSocomAmmo() },
                { "Socom's Max Ammo", () => AobManager.Instance.ReadSocomMaxAmmo() },
                { "Famas's Current Ammo", () => AobManager.Instance.ReadFamasAmmo() },
                { "Famas's Max Ammo", () => AobManager.Instance.ReadFamasMaxAmmo() },
                { "Grenade's Current Ammo", () => AobManager.Instance.ReadGrenadeAmmo() },
                { "Grenade's Max Ammo", () => AobManager.Instance.ReadGrenadeMaxAmmo() },
                { "Nikita's Current Ammo", () => AobManager.Instance.ReadNikitaAmmo() },
                { "Nikita's Max Ammo", () => AobManager.Instance.ReadNikitaMaxAmmo() },
                { "Stinger's Current Ammo", () => AobManager.Instance.ReadStingerAmmo() },
                { "Stinger's Max Ammo", () => AobManager.Instance.ReadStingerMaxAmmo() },
                { "Claymore's Current Ammo", () => AobManager.Instance.ReadClaymoreAmmo() },
                { "Claymore's Max Ammo", () => AobManager.Instance.ReadClaymoreMaxAmmo() },
                { "C4's Current Ammo", () => AobManager.Instance.ReadC4Ammo() },
                { "C4's Max Ammo", () => AobManager.Instance.ReadC4MaxAmmo() },
                { "Stun Grenade's Current Ammo", () => AobManager.Instance.ReadStunGrenadeAmmo() },
                { "Stun Grenade's Max Ammo", () => AobManager.Instance.ReadStunGrenadeMaxAmmo() },
                { "Chaff Grenade's Current Ammo", () => AobManager.Instance.ReadChaffGrenadeAmmo() },
                { "Chaff Grenade's Max Ammo", () => AobManager.Instance.ReadChaffGrenadeMaxAmmo() },
                { "PSG1's Current Ammo", () => AobManager.Instance.ReadPSG1Ammo() },
                { "PSG1's Max Ammo", () => AobManager.Instance.ReadPSG1MaxAmmo() },
            };

            foreach (var reading in damageReadings)
            {
                string message = reading.Value.Invoke();
                LoggingManager.Instance.Log($"\n\n{reading.Key}:\n{message}");
            }
        }
    }
}