using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItKarieraProjectTest.Presentation.Utility;
using Autofac;
using ItKarieraProjectTest.Presentation;

namespace ItKarieraProjectTest.Presentation
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = ContainerConfig.Configure();

            using var scope = container.BeginLifetimeScope();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = scope.Resolve<LoginForm>();
            FormFactory._scope = scope;
            Application.Run(loginForm);
        }
    }
}
