using System.Diagnostics;
using System.Text;
using static MGS1_MC_Cheat_Trainer.MemoryManager;

namespace MGS1_MC_Cheat_Trainer
{
    public class StringManager
    {
        private static StringManager instance;
        private static readonly object lockObj = new object();

        private StringManager()
        {
        }


        public static StringManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new StringManager();
                    }

                    return instance;
                }
            }
        }

        public enum LocationString
        {
            preope, // Opening
            select, // Dev Menu
            select1, // Dev Menu Stage select 1
            select2, // Dev Menu Stage Select 2
            select3, // Dev Menu Stage Select 3
            select4, // Dev Menu Stage Select 4
            selectd, // Dev Menu Demo Select
            sound, // Dev Menu vox test
            change, // Disc Change
            title, // Menu Screen
            options, // Options Screen
            brf, // Briefing Menu
            selectvr, // VR Missions Menu
            denosel, // Demo Theater
            vr01, // VR Stage 1
            vr02, // VR Stage 2
            vr07, // VR Stage 3
            vr03, // VR Stage 4
            vr05, // VR Stage 5
            vr09, // VR Stage 6
            vr04, // Stage 7
            vr06, // VR Stage 8
            vr08, // VR Stage 9
            vr10, // VR Stage 10
            vrdemo, // Developer Demo Play
            d00aa, // Dock Unused
            d00a, // Dock (Cutscene)
            s00a, // Dock
            s01a, // Heliport
            d01a, // Heliport (Cutscene)
            s02a, // Tank Hangar
            s02b, // Tank Hangar (Alternate)
            s02c, // Tank Hangar (Before Contacting Meryl)
            s02d, // Tank Hangar (After Contacting Meryl)
            s02e, // Tank Hanger (After Torture)
            s03a, // Cell
            d03a, // Cell (Cutscene)
            s03b, // Torture Room
            s03c, // Torture Room Cell
            s03e, // Cell (Fight)
            s04a, // Armory
            s04b, // Armory (Ocelot Fight)
            s05a, // Canyon
            s06a, // Nuke Building 1
            s07a, // Nuke Building B1
            s07b, // Commanders Room
            s08a, // Nuke Building 2
            s08b, // Lab (Gray Fox Fight)
            s08c, // Nuke Building B2
            s09a, // Cave
            s10a, // Underground Passage
            s10a1, // Underground Passage (Sniper Wolf Battle)
            s10a2, // Underground Passage (After Torture)
            s11a, // Communication Tower A
            s11b, // Roof
            s11b2, // Roof
            s11c, // Communication Tower B
            d11c, // Communication Tower B (Cutscene)
            s11c1, // Communication Tower B
            s11c2, // Communication Tower B
            s11d, // Tower Wall A
            s11e, // Communication Tower B (Elevator Fight)
            s11g, // Roof Communication Tower
            s11h, // Roof Communication Tower (Hind D Fight)
            s11i, // Walkway
            s11i2, // Walkway
            s12a, // SnowField
            s12a1, // SnowField
            s12b, // SnowField (After Sniper Wolf Battle)
            s12c, // SnowField (After Sniper Wolf Battle)
            s13a, // Blast Furnace
            s14e0, // Cargo Elevator
            s14e1, // Cargo Elevator
            s15a, // Warehouse
            s15b, // Warehouse NTH
            s16a, // Rex Hangar (1st floor)
            s16b, // Rex Hangar (2nd Floor)
            s16c, // Rex Hangar (3rd Floor)
            s16d, // Command Room
            d16e, // Rex Hangar (Cutscene)
            s17a, // Supply Rte (Rex Fight)
            s18a, // Liquid Fight
            d18a, // Liquid Fight (Cutscene)
            s19a, // Escape Route (Meryl)
            s19b, // Escape Route (Otacon)
            s20a, // Ending
            ending, // Ending(Part 2)
            roll, // Credits
            rank, // Rank Screen
        }

        public static readonly Dictionary<LocationString, string> LocationAreaNames =
            new Dictionary<LocationString, string>
            {
                { LocationString.preope, "Opening" },
                { LocationString.select, "Dev Menu" },
                { LocationString.select1, "Dev Menu Stage select 1" },
                { LocationString.select2, "Dev Menu Stage Select 2" },
                { LocationString.select3, "Dev Menu Stage Select 3" },
                { LocationString.select4, "Dev Menu Stage Select 4" },
                { LocationString.selectd, "Dev Menu Demo Select" },
                { LocationString.sound, "Dev Menu vox test" },
                { LocationString.change, "Disc Change" },
                { LocationString.title, "Menu Screen" },
                { LocationString.options, "Options Screen" },
                { LocationString.brf, "Briefing Menu" },
                { LocationString.selectvr, "VR Missions Menu" },
                { LocationString.denosel, "Demo Theater" },
                { LocationString.vr01, "VR Stage 1" },
                { LocationString.vr02, "VR Stage 2" },
                { LocationString.vr07, "VR Stage 3" },
                { LocationString.vr03, "VR Stage 4" },
                { LocationString.vr05, "VR Stage 5" },
                { LocationString.vr09, "VR Stage 6" },
                { LocationString.vr04, "Stage 7" },
                { LocationString.vr06, "VR Stage 8" },
                { LocationString.vr08, "VR Stage 9" },
                { LocationString.vr10, "VR Stage 10" },
                { LocationString.vrdemo, "Developer Demo Play" },
                { LocationString.d00aa, "Dock Unused" },
                { LocationString.d00a, "Dock (Cutscene)" },
                { LocationString.s00a, "Dock" },
                { LocationString.s01a, "Heliport" },
                { LocationString.d01a, "Heliport (Cutscene)" },
                { LocationString.s02a, "Tank Hangar" },
                { LocationString.s02b, "Tank Hangar (Alternate)" },
                { LocationString.s02c, "Tank Hangar (Before Contacting Meryl)" },
                { LocationString.s02d, "Tank Hangar (After Contacting Meryl)" },
                { LocationString.s02e, "Tank Hanger (After Torture)" },
                { LocationString.s03a, "Cell" },
                { LocationString.d03a, "Cell (Cutscene)" },
                { LocationString.s03b, "Torture Room" },
                { LocationString.s03c, "Torture Room Cell" },
                { LocationString.s03e, "Cell (Fight)" },
                { LocationString.s04a, "Armory" },
                { LocationString.s04b, "Armory (Ocelot Fight)" },
                { LocationString.s05a, "Canyon" },
                { LocationString.s06a, "Nuke Building 1" },
                { LocationString.s07a, "Nuke Building B1" },
                { LocationString.s07b, "Commanders Room" },
                { LocationString.s08a, "Nuke Building 2" },
                { LocationString.s08b, "Lab (Gray Fox Fight)" },
                { LocationString.s08c, "Nuke Building B2" },
                { LocationString.s09a, "Cave" },
                { LocationString.s10a, "Underground Passage" },
                { LocationString.s10a1, "Underground Passage (Sniper Wolf Battle)" },
                { LocationString.s10a2, "Underground Passage (After Torture)" },
                { LocationString.s11a, "Communication Tower A" },
                { LocationString.s11b, "Roof" },
                { LocationString.s11b2, "Roof" },
                { LocationString.s11c, "Communication Tower B" },
                { LocationString.d11c, "Communication Tower B (Cutscene)" },
                { LocationString.s11c1, "Communication Tower B" },
                { LocationString.s11c2, "Communication Tower B" },
                { LocationString.s11d, "Tower Wall A" },
                { LocationString.s11e, "Communication Tower B (Elevator Fight)" },
                { LocationString.s11g, "Roof Communication Tower" },
                { LocationString.s11h, "Roof Communication Tower (Hind D Fight)" },
                { LocationString.s11i, "Walkway" },
                { LocationString.s11i2, "Walkway" },
                { LocationString.s12a, "SnowField" },
                { LocationString.s12a1, "SnowField" },
                { LocationString.s12b, "SnowField (After Sniper Wolf Battle)" },
                { LocationString.s12c, "SnowField (After Sniper Wolf Battle)" },
                { LocationString.s13a, "Blast Furnace" },
                { LocationString.s14e0, "Cargo Elevator" },
                { LocationString.s14e1, "Cargo Elevator" },
                { LocationString.s15a, "Warehouse" },
                { LocationString.s15b, "Warehouse NTH" },
                { LocationString.s16a, "Rex Hangar (1st floor)" },
                { LocationString.s16b, "Rex Hangar (2nd Floor)" },
                { LocationString.s16c, "Rex Hangar (3rd Floor)" },
                { LocationString.s16d, "Command Room" },
                { LocationString.d16e, "Rex Hangar (Cutscene)" },
                { LocationString.s17a, "Supply Rte (Rex Fight)" },
                { LocationString.s18a, "Liquid Fight" },
                { LocationString.d18a, "Liquid Fight (Cutscene)" },
                { LocationString.s19a, "Escape Route (Meryl)" },
                { LocationString.s19b, "Escape Route (Otacon)" },
                { LocationString.s20a, "Ending" },
                { LocationString.ending, "Ending(Part 2)" },
                { LocationString.roll, "Credits" },
                { LocationString.rank, "Rank Screen" },
            };

        public string FindLocationStringDirectlyInRange()
        {
            Process process = GetMGS1Process();
            if (process == null)
            {
                return "Game process not found.";
            }

            // This will need to be modified for dynamic memory as unlike MGS3 nothing we use is static
            IntPtr processHandle = OpenGameProcess(process);
            IntPtr baseAddress = process.MainModule.BaseAddress;
            IntPtr startAddress = IntPtr.Add(baseAddress, 0x1C00000);
            IntPtr endAddress = IntPtr.Add(baseAddress, 0x1D00000);
            long size = endAddress.ToInt64() - startAddress.ToInt64();
            // End of where dynamic changes will be needed

            foreach (StringManager.LocationString location in Enum.GetValues(typeof(StringManager.LocationString)))
            {
                var locationString = location.ToString();
                byte[] pattern = Encoding.ASCII.GetBytes(locationString);
                string mask = new string('x', pattern.Length);

                IntPtr foundAddress =
                    MemoryManager.Instance.ScanMemory(processHandle, startAddress, size, pattern, mask);
                if (foundAddress != IntPtr.Zero)
                {
                    string areaName = StringManager.LocationAreaNames.TryGetValue(location, out var name)
                        ? name
                        : "Unknown Area";

                    // Checking for cutscene indicators These are MGS3's cutscene suffixes
                    // However we can change these to MGS1's if needed and we find a suffix pattern is needed
                    foreach (var suffix in new[] { "_0", "_1" })
                    {
                        byte[] cutscenePattern = Encoding.ASCII.GetBytes(locationString + suffix);
                        IntPtr cutsceneFoundAddress = MemoryManager.Instance.ScanMemory(processHandle, startAddress,
                            size, cutscenePattern, mask + "x" + "x");

                        if (cutsceneFoundAddress != IntPtr.Zero)
                        {
                            NativeMethods.CloseHandle(processHandle);
                            return
                                $"Location String: {locationString}{suffix} (Cutscene) \nArea Name: {areaName} \nMemory Address: {cutsceneFoundAddress.ToString("X")}";
                        }
                    }

                    NativeMethods.CloseHandle(processHandle);
                    return
                        $"Location String: {locationString} \nArea Name: {areaName} \nMemory Address: {foundAddress.ToString("X")}";
                }
            }

            NativeMethods.CloseHandle(processHandle);
            return "No Location String found in specified range.";
        }
    }
}