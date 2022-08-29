using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using TeamsFix.Actions;

namespace TeamsFix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Window;
        private delegate void UpdateMessage(string msg);
        public delegate void ChangeButtonStatus(bool option);

        public MainWindow()
        {
            InitializeComponent();
            Window = this;
        }

        //TODO: Adicionar uma pequena aba "Sobre", com o link do meu github, versão e detalhes sobre o exe (localização do arquivo de logs, etc)
        //TODO: Alterar as cores no momento em que o mouse fica sobre o botão

        private void ButtonRepair(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                ButtonStatus(false);

                try
                {
                    Teams.KillProcesses();
                    Teams.Repair();
                    Window.Message("Reparo do Microsoft Teams concluído.");
                    Thread.Sleep(5000);
                    Window.Message("");
                }
                catch (Exception ex)
                {
                    Window.Message("Ocorreu um erro no reparo do Teams.");
                    Logger.InsertInfo(ex.ToString());
                    throw;
                }

                ButtonStatus(true);

            }).Start();
        }

        private void ButtonReinstall(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                ButtonStatus(false);

                try
                {
                    Teams.KillProcesses();
                    Teams.Uninstall();
                    Teams.Install();
                    Window.Message("Reinstalação do Teams concluída.");
                    Thread.Sleep(5000);
                    Window.Message("");
                }
                catch (Exception ex)
                {
                    Window.Message("Ocorreu um erro na reinstalação do Teams.");
                    Logger.InsertInfo(ex.ToString());
                    throw;
                }

                ButtonStatus(true);

            }).Start();
        }

        public void EnableButtons(bool option)
        {
            Repair.IsHitTestVisible = option;
            Reinstall.IsHitTestVisible = option;
        }

        public void SetMessage(string msg)
        {
            LabelMsg.Content = msg;
            LabelMsg.Visibility = Visibility;
        }

        public void Message(string msg)
        {
            Dispatcher.BeginInvoke(new UpdateMessage(SetMessage), DispatcherPriority.Render, new object[] { msg });
            Logger.InsertInfo(msg);
            Thread.Sleep(1500);
        }

        public void ButtonStatus(bool option)
        {
            Dispatcher.BeginInvoke(new ChangeButtonStatus(EnableButtons), DispatcherPriority.Render, new object[] { option });
        }
    }
}