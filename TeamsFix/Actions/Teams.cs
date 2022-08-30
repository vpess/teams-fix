﻿using System;
using System.Diagnostics;
using System.IO;

namespace TeamsFix.Actions
{
    class Teams
    {
        private static readonly string InstallCmd = $@"/C {Path.publicDocuments}\Teams_windows_x64.exe -s";
        private static readonly string UninstallCmd = $@"/C {Path.localAppData}\Microsoft\Teams\Update.exe --uninstall -s";

        public static void KillProcesses()
        {
            ProcessOperation.Kill("OUTLOOK");
            ProcessOperation.Kill("TEAMS");
        }

        public static void Install()
        {
            Download.Run();

            try
            {
                MainWindow.Window.Message("Executando a instalação do Microsoft Teams...");
                Process installTeams = ProcessOperation.Create("cmd.exe", InstallCmd);
                installTeams.Start();
                installTeams.WaitForExit();
                MainWindow.Window.Message("Instalação do Teams concluída.");
            }
            catch (Exception ex)
            {
                MainWindow.Window.Message("Ocorreu um erro na instalação do Teams.");
                Logger.InsertInfo(ex.ToString());
            }
        }

        public static void Uninstall()
        {
            MainWindow.Window.Message("Executando a desinstalação do Microsoft Teams...");

            try
            {
                Process uninstallTeams = ProcessOperation.Create("cmd.exe", UninstallCmd);
                uninstallTeams.Start();
                uninstallTeams.WaitForExit();
                MainWindow.Window.Message("Desinstalação do Teams concluída.");
            }
            catch (Exception ex)
            {
                MainWindow.Window.Message("Ocorreu um erro na desinstalação do Teams.");
                Logger.InsertInfo(ex.ToString());
            }
        }

        public static void Repair()
        {
            MainWindow.Window.Message($@"Executando o reparo do Microsoft Teams.");
            try
            {
                Directory.Delete($@"{Path.roamingAppData}\Microsoft\Teams", true);
                MainWindow.Window.Message($@"Arquivos em {Path.roamingAppData}\Microsoft\Teams removidos.");
            }
            catch (DirectoryNotFoundException ex)
            {
                MainWindow.Window.Message($"Pasta de configuração do Microsoft Teams inexistente.");
                Logger.InsertInfo(ex.ToString());
            }
        }
    }
}
