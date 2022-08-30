using System;
using System.Threading;
using System.Windows;

namespace TeamsFix.Actions
{
    class Setup
    {
        private static void CheckTeams()
        {
            if (!Software.CheckInstallation("Microsoft Teams"))
            {
                MessageBox.Show("O Microsoft Teams não está instalado no sistema.", "Software nao encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
                MainWindow.Window.Close();
            }
        }

        public static void Repair()
        {
            CheckTeams();

            try
            {
                Teams.KillProcesses();
                Teams.Repair();
                MainWindow.Window.Message("Processo de reparo do Microsoft Teams concluído.");
                Thread.Sleep(5000);
                MainWindow.Window.Message("");
            }
            catch (Exception ex)
            {
                MainWindow.Window.Message("Ocorreu um erro no reparo do Teams.");
                Logger.InsertInfo(ex.ToString());
                throw;
            }
        }

        public static void Reinstall()
        {
            CheckTeams();

            try
            {
                Teams.KillProcesses();
                Teams.Uninstall();
                Teams.Install();
                MainWindow.Window.Message("Processo de reinstalação do Microsoft Teams concluído.");
                Thread.Sleep(5000);
                MainWindow.Window.Message("");
            }
            catch (Exception ex)
            {
                MainWindow.Window.Message("Ocorreu um erro na reinstalação do Teams.");
                Logger.InsertInfo(ex.ToString());
                throw;
            }

        }
    }
}
