using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace FactorioHeadlessGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyLoader.AssemblyResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppController controller = new AppController();
            controller.Run(Environment.GetCommandLineArgs());
        }

        private class AppController : WindowsFormsApplicationBase
        {
            public AppController() : base(AuthenticationMode.Windows)
            {
                this.IsSingleInstance = false;
                this.EnableVisualStyles = true;
                this.SaveMySettingsOnExit = false;
            }

            protected override void OnCreateMainForm()
            { }

            protected override bool OnStartup(StartupEventArgs eventArgs)
            {
                string lower,
                    configFile = string.Empty;
                for (int i = 0; i < eventArgs.CommandLine.Count; i++)
                {
                    lower = eventArgs.CommandLine[i].ToLower();
                    if (lower.StartsWith("/config:"))
                        configFile = eventArgs.CommandLine[i].Remove(0, 8);
                }
                MyMainMenu mainmenu = new MyMainMenu(configFile);
                this.MainForm = mainmenu;
                return base.OnStartup(eventArgs);
            }
        }
    }
}
