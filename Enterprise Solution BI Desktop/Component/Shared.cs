using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;


namespace EnterpriseSolutionBIDesktop
{
    public class Shared
    {
        public static string AssemblyFile = "";
        public static string Target = "Types.xml";

        public static string SystemDatabase = "data source=Rcserver"+"'\'"+"sqlexpress;initial catalog=Framework;integrated security=SSPI;persist security info=False;packet size=4096";

        public static int CommandTimeout = 86400;
        public static int ReindexFillFactor = 0;

       
        //设置程序开机自动运行
        public static void SetRegistryIsStart(bool IsStart)
        {
            if (IsStart)
            {
                try
                {
                    string strAssName = Application.StartupPath + @"\" + Application.ProductName + @".exe";
                    string ShortFileName = Application.ProductName;

                    RegistryKey rgkRun = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    if (rgkRun == null)
                    {
                        rgkRun = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                        rgkRun.SetValue(ShortFileName, strAssName);
                    }
                    else
                    {
                        rgkRun.SetValue(ShortFileName, strAssName);
                    }
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true).DeleteValue(Application.ProductName, false);
                }
                catch
                {

                }
            }
        }
        
        public static DataTable TableFunction
        {
            get { return _tableFunction; }
            set { _tableFunction = value; }
        }

        public static string FramwworkConnectionString
        {
            get { return _framwworkConnectionString; }
            set { _framwworkConnectionString = value; }
        }

        private static string _framwworkConnectionString;

        private static DataTable _tableFunction;

         static Shared()
         {
             if (_tableFunction == null)
                 _tableFunction = new DataTable();

             _tableFunction.Columns.Add("Index", typeof(int));
             _tableFunction.Columns.Add("Text", typeof(string));
             _tableFunction.Columns.Add("Tag", typeof(string));
             _tableFunction.Columns.Add("IsSystem", typeof(int));
             _tableFunction.Columns.Add("ImageIndex", typeof(int));
             _tableFunction.Columns.Add("Parameter", typeof(string));
             _tableFunction.PrimaryKey = new DataColumn[] { _tableFunction.Columns["Index"] };
         }

         public const string DefaultNamespace = "Foundation.Maintenance";

         [DllImport("kernel32.dll")]
         private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
         public static DialogResult ShowConfirm(string message)
         {
             return ShowConfirm(message, null);
         }

         public static DialogResult ShowConfirm(string message, object[] args)
         {
             return ShowConfirm(new ActiveWindowHandle(), message, args);
         }

         public static DialogResult ShowConfirm(string message, object[] args, MessageBoxButtons buttonStyle)
         {
             return ShowConfirm(new ActiveWindowHandle(), message, args, buttonStyle);
         }

         public static DialogResult ShowConfirm(IWin32Window owner, string message, object[] args)
         {
             return ShowConfirm(owner, message, args, MessageBoxButtons.YesNo);
         }

        public static DialogResult ShowConfirm(IWin32Window owner, string message, object[] args, MessageBoxButtons buttonStyle)
        {
            //message = Microsoft.Common.Shared.TranslateText(message);
            if ((args != null) && (args.Length > 0))
            {
                message = string.Format(message, args);
            }
            try
            {
                return MessageBox.Show(owner, message, "Confirm", buttonStyle, MessageBoxIcon.Question);
            }
            catch
            {
                return MessageBox.Show(message, "Confirm", buttonStyle, MessageBoxIcon.Question);
            }
        }

        private sealed class ActiveWindowHandle : IWin32Window
         {
             [DllImport("user32.dll")]
             private static extern int GetForegroundWindow();

             public IntPtr Handle
             {
                 get
                 {
                     return new IntPtr(GetForegroundWindow());
                 }
             }
         }
    }

    public static class DatatGridViewExtensions
    {
        public static void SetColumnSortMode(this DataGridView dataGridView, DataGridViewColumnSortMode sortMode)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = sortMode;
            }
        }
    }

                             
    public partial class ConfigHelper
    {
        /// <summary> /// Gets whether the specified path is a valid absolute file path. /// </summary> 
        /// <param name="path">Any path. OK if null or empty.</param> 
        static public bool IsValidPath(string path)
        {
            Regex r = new Regex(@"^(([a-zA-Z]:)|(\))(\{1}|((\{1})[^\]([^/:*?<>""|]*))+)$");
            return r.IsMatch(path);
        }


        public static string GetString(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static int GetInteger(string key)
        {
            int value = 0;
            if ((int.TryParse(GetString(key), out value)))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        public static decimal GetDecimal(string key)
        {
            decimal value = default(decimal);
            if ((decimal.TryParse(GetString(key), out value)))
            {
                return value;
            }
            else
            {
                return 0m;
            }
        }

        public static bool GetBoolean(string key)
        {
            bool value = false;
            if ((bool.TryParse(GetString(key), out value)))
            {
                return value;
            }
            else
            {
                return false;
            }
        }
    }

}
