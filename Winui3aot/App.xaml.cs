using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

using Microsoft.Data.Sqlite;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Winui3aot
{

    public partial class App : Application
    {
        public static DispatcherQueue dispatcherQueue;
        public static SqliteConnection con;
        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            dispatcherQueue = DispatcherQueue.GetForCurrentThread();
            #region 初始化数据库
            con = new("Data Source=TestSqlite.sqlite");
            con.Open();
            try
            {
                var cmd = new SqliteCommand("create table settings(Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "Key TEXT NOT NULL UNIQUE," +
                    "Value TEXT NOT NULL)"
                    , con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            #endregion
            m_window = new MainWindow();
            m_window.Activate();
        }

        private WindowEx m_window;
    }
}
