using Frosty.Core;
using Frosty.Core.Controls;
using FrostySdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AutoRunPlugin.Execution
{
    public class AutoRunExecutionAction : ExecutionAction
    {
        private void ReportProgress(ILogger logger, int current, int total)
        {
            if (total > 0)
                logger.Log("progress:" + current / (float)total * 100d);
        }

        public override Action<ILogger, PluginManagerType, CancellationToken> PreLaunchAction => new Action<ILogger, PluginManagerType, CancellationToken>((ILogger logger, PluginManagerType type, CancellationToken token) =>
        {
            // Only run when AutoRun is enabled
            if (Config.Get("AutoRun_Enabled", false, ConfigScope.Global) is false)
                return;
            //token.ThrowIfCancellationRequested();

            // Calculate total amount
            logger.Log("Calculating total amount");
            List<string> Files = new List<string>();

            // FrostyDir
            logger.Log("Looking for files in Frosty directory");
            if (Config.Get("AutoRun_FrostyDir_AutoRunEnabled", false, ConfigScope.Global) is true && Config.Get("AutoRun_FrostyDir_PreLaunchEnabled", false, ConfigScope.Global) is true)
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AutoRun\\PreLaunch");
                Files.AddRange(Directory.GetFiles(Directory.GetCurrentDirectory() + "\\AutoRun\\PreLaunch\\"));
            }
            //token.ThrowIfCancellationRequested();

            // GameDir
            logger.Log("Looking for files in Game directory");
            if (Config.Get("AutoRun_GameDir_AutoRunEnabled", false, ConfigScope.Game) is true && Config.Get("AutoRun_GameDir_PreLaunchEnabled", false, ConfigScope.Game) is true)
            {
                Directory.CreateDirectory(App.FileSystem.BasePath + "AutoRun\\PreLaunch\\");
                Files.AddRange(Directory.GetFiles(App.FileSystem.BasePath + "AutoRun\\PreLaunch\\"));
            }
            //token.ThrowIfCancellationRequested();

            // PackDir (ModData)
            logger.Log("Looking for files in Pack directory");
            try
            {
                if (Config.Get("AutoRun_PackDir_AutoRunEnabled", false, ConfigScope.Pack) is true && Config.Get("AutoRun_PackDir_PreLaunchEnabled", false, ConfigScope.Pack) is true)
                {
                    Directory.CreateDirectory(App.FileSystem.BasePath + "\\ModData\\" + App.SelectedPack + "\\AutoRun\\PreLaunch\\");
                    Files.AddRange(Directory.GetFiles(App.FileSystem.BasePath + "\\ModData\\" + App.SelectedPack + "\\AutoRun\\PreLaunch\\"));
                }
            }
            catch (Exception e)
            {
                FrostyExceptionBox.Show(e, "Auto Run Plugin (PackDir)");
            }
            //token.ThrowIfCancellationRequested();

            App.Logger.Log("[PreLaunch] " + Files.Count + " files found");

            // (Debug) Print all file paths
            if (Config.Get("AutoRun_Debug_LogAllFiles", false, ConfigScope.Global))
            {
                logger.Log("[Debug] Printing all file paths");
                App.Logger.Log("[PreLaunch] [Debug] All file paths:");
                foreach (var path in Files)
                {
                    App.Logger.Log("[PreLaunch] [Debug] " + path);
                    //token.ThrowIfCancellationRequested();
                }
            }

            GC.Collect();

            // Run all files
            int i = 0;
            foreach (var path in Files)
            {
                try
                {
                    logger.Log($"[{++i}/{Files.Count}] {Path.GetFileName(path)}");
                    ReportProgress(logger, i, Files.Count);
                    //token.ThrowIfCancellationRequested();
                    Process.Start(path);
                    //token.ThrowIfCancellationRequested();
                }
                catch (Exception e)
                {
                    FrostyExceptionBox.Show(e, "Auto Run Plugin");
                }
                //token.ThrowIfCancellationRequested();
            }

            logger.Log("Pre Launch Complete");
            App.Logger.Log("Pre Launch Complete");
            GC.Collect();
        });

        public override Action<ILogger, PluginManagerType, CancellationToken> PostLaunchAction => new Action<ILogger, PluginManagerType, CancellationToken>((ILogger logger, PluginManagerType type, CancellationToken token) =>
        {
            // Only run when AutoRun is enabled
            if (Config.Get("AutoRun_Enabled", false, ConfigScope.Global) is false)
                return;
            //token.ThrowIfCancellationRequested();

            // Calculate total amount
            logger.Log("Calculating total amount");
            List<string> Files = new List<string>();

            // FrostyDir
            logger.Log("Looking for files in Frosty directory");
            if (Config.Get("AutoRun_FrostyDir_AutoRunEnabled", false, ConfigScope.Global) is true && Config.Get("AutoRun_FrostyDir_PostLaunchEnabled", false, ConfigScope.Global) is true)
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AutoRun\\PostLaunch\\");
                Files.AddRange(Directory.GetFiles(Directory.GetCurrentDirectory() + "\\AutoRun\\PostLaunch\\"));
            }
            //token.ThrowIfCancellationRequested();

            // GameDir
            logger.Log("Looking for files in Game directory");
            if (Config.Get("AutoRun_GameDir_AutoRunEnabled", false, ConfigScope.Game) is true && Config.Get("AutoRun_GameDir_PostLaunchEnabled", false, ConfigScope.Game) is true)
            {
                Directory.CreateDirectory(App.FileSystem.BasePath + "AutoRun\\PostLaunch\\");
                Files.AddRange(Directory.GetFiles(App.FileSystem.BasePath + "AutoRun\\PostLaunch\\"));
            }
            //token.ThrowIfCancellationRequested();

            // PackDir (ModData)
            logger.Log("Looking for files in Pack directory");
            try
            {
                if (Config.Get("AutoRun_PackDir_AutoRunEnabled", false, ConfigScope.Pack) is true && Config.Get("AutoRun_PackDir_PostLaunchEnabled", false, ConfigScope.Pack) is true)
                {
                    Directory.CreateDirectory(App.FileSystem.BasePath + "\\ModData\\" + App.SelectedPack + "\\AutoRun\\PostLaunch\\");
                    Files.AddRange(Directory.GetFiles(App.FileSystem.BasePath + "\\ModData\\" + App.SelectedPack + "\\AutoRun\\PostLaunch\\"));
                }
            }
            catch (Exception e)
            {
                FrostyExceptionBox.Show(e, "Auto Run Plugin (PackDir)");
            }
            //token.ThrowIfCancellationRequested();

            App.Logger.Log("[PostLaunch] " + Files.Count + " files found");

            // (Debug) Print all file paths
            if (Config.Get("AutoRun_Debug_LogAllFiles", false, ConfigScope.Global))
            {
                logger.Log("[Debug] Printing all file paths");
                App.Logger.Log("[PostLaunch] [Debug] All file paths:");
                //token.ThrowIfCancellationRequested();
                foreach (var path in Files)
                {
                    App.Logger.Log("[PostLaunch] [Debug] " + path);
                    //token.ThrowIfCancellationRequested();
                }
            }

            GC.Collect();

            // Run all files
            int i = 0;
            foreach (var path in Files)
            {
                try
                {
                    logger.Log($"[{++i}/{Files.Count}] {Path.GetFileName(path)}");
                    ReportProgress(logger, i, Files.Count);
                    //token.ThrowIfCancellationRequested();
                    Process.Start(path);
                    //token.ThrowIfCancellationRequested();
                }
                catch (Exception e)
                {
                    FrostyExceptionBox.Show(e, "Auto Run Plugin");
                }
                //token.ThrowIfCancellationRequested();
            }

            logger.Log("Post Launch Complete");
            App.Logger.Log("Post Launch Complete");
            GC.Collect();
        });
    }
}
