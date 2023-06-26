using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EnterpriseSolutionBIDesktop
{
    static class Program
    {
        private static string _connectionString;

        public static string ConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["KPI"].ConnectionString;


        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(ApplicationOnThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        //static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    return EmbeddedAssembly.Get(args.Name);
        //}

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                using (ErrorDialog errorForm = new ErrorDialog())
                {
                    errorForm.Error = e.ExceptionObject as Exception;
                    errorForm.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                using (ErrorDialog errorForm = new ErrorDialog())
                {
                    errorForm.Error = t.Exception;
                    errorForm.ShowDialog();
                }
            }
            catch
            {
                throw;
            }
        }

        public static void ShowError(Exception exception)
        {
            try
            {
                using (ErrorDialog errorForm = new ErrorDialog())
                {
                    errorForm.Error = exception;
                    errorForm.ShowDialog();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
