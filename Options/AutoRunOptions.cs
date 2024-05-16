using Frosty.Core;
using Frosty.Core.Controls;
using FrostySdk.Attributes;
using System;
using System.IO;

namespace AutoRunPlugin.Options
{
    [DisplayName("Auto Run Options")]
    public class AutoRunOptions : OptionsExtension
    {
        [Category("_General")]
        [Description("Main switch, enable to allow all others options\r\nWhen this option is turned off, all auto run options are disabled. However, it may not appear to be disabled in the Config window. That's just a display bug.")]
        [DisplayName("Enable Auto Run")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        public bool AutoRunEnabled { get; set; } = false;

        [Category("Frosty Directory")]
        [Description("Enables auto run for Frosty directory\r\nThis will create AutoRun folder in Frosty directory")]
        [DisplayName("Enable Auto Run")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        [DependsOn("AutoRunEnabled")]
        public bool FrostyDir_AutoRunEnabled { get; set; } = false;

        [Category("Frosty Directory")]
        [Description("Auto run pre launch files for Frosty directory\r\nThis will create AutoRun\\PreLaunch folder in Frosty directory")]
        [DisplayName("Enable Pre Launch")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        [DependsOn("FrostyDir_AutoRunEnabled")]
        public bool FrostyDir_PreLaunchEnabled { get; set; } = false;

        [Category("Frosty Directory")]
        [Description("Auto run post launch files for Frosty directory\r\nThis will create AutoRun\\PostLaunch folder in Frosty directory")]
        [DisplayName("Enable Post Launch")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        [DependsOn("FrostyDir_AutoRunEnabled")]
        public bool FrostyDir_PostLaunchEnabled { get; set; } = false;

        [Category("Game Directory")]
        [Description("Enables auto run for Game directory\r\nThis will create AutoRun folder in Game directory")]
        [DisplayName("Enable Auto Run")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        [DependsOn("AutoRunEnabled")]
        public bool GameDir_AutoRunEnabled { get; set; } = false;

        [Category("Game Directory")]
        [Description("Auto run pre launch files for Game directory\r\nThis will create AutoRun\\PreLaunch folder in Game directory")]
        [DisplayName("Enable Pre Launch")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        [DependsOn("GameDir_AutoRunEnabled")]
        public bool GameDir_PreLaunchEnabled { get; set; } = false;

        [Category("Game Directory")]
        [Description("Auto run post launch files for Game directory\r\nThis will create AutoRun\\PostLaunch folder in Game directory")]
        [DisplayName("Enable Post Launch")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        [DependsOn("GameDir_AutoRunEnabled")]
        public bool GameDir_PostLaunchEnabled { get; set; } = false;

        [Category("Pack Directory")]
        [Description("Warning: Experimental feature\r\nEnables auto run for Pack directory\r\nThis will create ModData\\<PackName>\\AutoRun folder in Game directory")]
        [DisplayName("Enable Auto Run")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        [DependsOn("AutoRunEnabled")]
        public bool PackDir_AutoRunEnabled { get; set; } = false;

        [Category("Pack Directory")]
        [Description("Warning: Experimental feature\r\nAuto run pre launch files for Pack directory\r\nThis will create ModData\\<PackName>\\AutoRun\\PreLaunch folder in Game directory")]
        [DisplayName("Enable Pre Launch")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        [DependsOn("PackDir_AutoRunEnabled")]
        public bool PackDir_PreLaunchEnabled { get; set; } = false;

        [Category("Pack Directory")]
        [Description("Warning: Experimental feature\r\nAuto run post launch files for Pack directory\r\nThis will create ModData\\<PackName>\\AutoRun\\PostLaunch folder in Game directory")]
        [DisplayName("Enable Post Launch")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        [DependsOn("PackDir_AutoRunEnabled")]
        public bool PackDir_PostLaunchEnabled { get; set; } = false;

        [Category("Debug")]
        [Description("When launching, print all found file paths to log")]
        [DisplayName("Log All Files")]
        [EbxFieldMeta(FrostySdk.IO.EbxFieldType.Boolean)]
        public bool Debug_LogAllFiles { get; set; } = false;

        public override void Load()
        {
            AutoRunEnabled = Config.Get("AutoRun_Enabled", false, ConfigScope.Global);
            FrostyDir_AutoRunEnabled = Config.Get("AutoRun_FrostyDir_AutoRunEnabled", false, ConfigScope.Global);
            FrostyDir_PreLaunchEnabled = Config.Get("AutoRun_FrostyDir_PreLaunchEnabled", false, ConfigScope.Global);
            FrostyDir_PostLaunchEnabled = Config.Get("AutoRun_FrostyDir_PostLaunchEnabled", false, ConfigScope.Global);
            GameDir_AutoRunEnabled = Config.Get("AutoRun_GameDir_AutoRunEnabled", false, ConfigScope.Game);
            GameDir_PreLaunchEnabled = Config.Get("AutoRun_GameDir_PreLaunchEnabled", false, ConfigScope.Game);
            GameDir_PostLaunchEnabled = Config.Get("AutoRun_GameDir_PostLaunchEnabled", false, ConfigScope.Game);
            PackDir_AutoRunEnabled = Config.Get("AutoRun_PackDir_AutoRunEnabled", false, ConfigScope.Pack);
            PackDir_PreLaunchEnabled = Config.Get("AutoRun_PackDir_PreLaunchEnabled", false, ConfigScope.Pack);
            PackDir_PostLaunchEnabled = Config.Get("AutoRun_PackDir_PostLaunchEnabled", false, ConfigScope.Pack);

            Debug_LogAllFiles = Config.Get("AutoRun_Debug_LogAllFiles", false, ConfigScope.Global);
        }

        public override void Save()
        {
            Config.Add("AutoRun_Enabled", AutoRunEnabled, ConfigScope.Global);
            Config.Add("AutoRun_FrostyDir_AutoRunEnabled", FrostyDir_AutoRunEnabled, ConfigScope.Global);
            Config.Add("AutoRun_FrostyDir_PreLaunchEnabled", FrostyDir_PreLaunchEnabled, ConfigScope.Global);
            Config.Add("AutoRun_FrostyDir_PostLaunchEnabled", FrostyDir_PostLaunchEnabled, ConfigScope.Global);
            Config.Add("AutoRun_GameDir_AutoRunEnabled", GameDir_AutoRunEnabled, ConfigScope.Game);
            Config.Add("AutoRun_GameDir_PreLaunchEnabled", GameDir_PreLaunchEnabled, ConfigScope.Game);
            Config.Add("AutoRun_GameDir_PostLaunchEnabled", GameDir_PostLaunchEnabled, ConfigScope.Game);
            try
            {
                Config.Add("AutoRun_PackDir_AutoRunEnabled", PackDir_AutoRunEnabled, ConfigScope.Pack);
                Config.Add("AutoRun_PackDir_PreLaunchEnabled", PackDir_PreLaunchEnabled, ConfigScope.Pack);
                Config.Add("AutoRun_PackDir_PostLaunchEnabled", PackDir_PostLaunchEnabled, ConfigScope.Pack);
            }
            catch {}

            Config.Add("AutoRun_Debug_LogAllFiles", Debug_LogAllFiles, ConfigScope.Global);

            try
            {
                if (AutoRunEnabled is true)
                {
                    if (FrostyDir_AutoRunEnabled is true)
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AutoRun");
                    if (FrostyDir_PreLaunchEnabled is true)
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AutoRun\\PreLaunch");
                    if (FrostyDir_PostLaunchEnabled is true)
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AutoRun\\PostLaunch");
                    
                    if (GameDir_AutoRunEnabled is true)
                        Directory.CreateDirectory(App.FileSystem.BasePath + "AutoRun");
                    if (GameDir_PreLaunchEnabled is true)
                        Directory.CreateDirectory(App.FileSystem.BasePath + "AutoRun\\PreLaunch");
                    if (GameDir_PostLaunchEnabled is true)
                        Directory.CreateDirectory(App.FileSystem.BasePath + "AutoRun\\PostLaunch");
                }
            }
            catch (Exception e)
            {
                FrostyExceptionBox.Show(e, "Auto Run Plugin");
            }

            try
            {
                if (AutoRunEnabled is true && String.IsNullOrEmpty(App.SelectedPack) is false)
                {
                    if (PackDir_AutoRunEnabled is true)
                        Directory.CreateDirectory(App.FileSystem.BasePath + "\\ModData\\" + App.SelectedPack + "\\AutoRun");
                    if (PackDir_PreLaunchEnabled is true)
                        Directory.CreateDirectory(App.FileSystem.BasePath + "\\ModData\\" + App.SelectedPack + "\\AutoRun\\PreLaunch");
                    if (PackDir_PostLaunchEnabled is true)
                        Directory.CreateDirectory(App.FileSystem.BasePath + "\\ModData\\" + App.SelectedPack + "\\AutoRun\\PostLaunch");
                }
            }
            catch (Exception e)
            {
                FrostyExceptionBox.Show(e, "Auto Run Plugin");
            }
        }
    }
}