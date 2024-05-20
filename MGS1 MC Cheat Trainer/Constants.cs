using System;
using System.Diagnostics;

namespace MGS1_MC_Cheat_Trainer
{
    public class Constants
    {
        public const string PROCESS_NAME = "METAL GEAR SOLID";

        // For reading different memory types and their values
        public enum DataType
        {
            // UInt = Unsigned Integer (No negative values)
            // Int = Signed Integer (Negative and positive values)
            UInt8, // Unsigned Byte
            Int8,  // Signed Byte
            Int16, // Signed Short
            UInt16,// Unsigned Short
            Int32, // Signed 4 byte integer
            UInt32, // Unsigned 4 byte integer
            Float, // 4 byte floating point number
            Int64, // Signed 8 byte integer
            UInt64, // Unsigned 8 byte integer
            Double, // 8 byte floating point number
            ByteArray, // For anything in between or larger than 8 bytes
        }

        public enum LifeStates
        {
            CurrentLife = 1038,
            MaxLife = 1036
        }

        public enum WeaponAmmo
        { 
          SocomAmmo = 1026,
          FamasAmmo = 1024,
          GrenadeAmmo = 1022,
          NikitaAmmo = 1020,
          StingerAmmo = 1018,
          ClaymoreAmmo = 1016,
          C4Ammo = 1014,
          StunGrenadeAmmo = 1012,
          ChaffGrenadeAmmo = 1010,
          PSG1Ammo = 1008,
          // Max amounts
          SocomMaxAmmo = 1006,
          FamasMaxAmmo = 1004,
          GrenadeMaxAmmo = 1002,
          NikitaMaxAmmo = 1000,
          StingerMaxAmmo = 998,
          ClaymoreMaxAmmo = 996,
          C4MaxAmmo = 994,
          StunGrenadeMaxAmmo = 992,
          ChaffGrenadeMaxAmmo = 990,
          PSG1MaxAmmo = 988,
        }

        public enum Items
        {
            Cigs = 986,
            Scope = 984,
            CBoxA = 982,
            CBoxB = 980,
            CBoxC = 978,
            NightVisionGoggles = 976, 
            ThermalGoggles = 974,
            GasMask = 972,
            BodyArmor = 970,
            Ketchup = 968,
            StealthCamo = 966,
            Bandana = 964,
            Camera = 962,
            Rations = 960,
            ColdMedicine = 958, 
            Diazepam = 956,
            PalKey = 954,
            PalKeyTemp = 930,
            CardKey = 952,
            TimeBomb = 950,
            MineDetector = 948,
            MoDisc = 946,
            Rope = 944,
            Handkerchief = 942,
            SocomSuppressor = 940,
            // Max amounts
            RationMax = 938,
            MedicineMax = 936,
            DiazepamMax = 934,
        }

        public enum GameStats
        {
            AlertsTriggered = 904,
            EnemiesKilled = 902,
            RationsUsed = 888,
            ContinuesUsed = 886,
            PlayTime = 880,
            TimesSaved = 862,
        }

    }
}