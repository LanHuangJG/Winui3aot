using System;
using System.Diagnostics;

using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using Winui3aot.Helper;
using Winui3aot.Pages;

using WinUIEx;


namespace Winui3aot
{
    public sealed partial class MainWindow : WindowEx
    {

        private Process BBDownServer;
        public MainWindow()
        {
            InitializeComponent();
            current = this;
            ExtendsContentIntoTitleBar = true;
            this.CenterOnScreen();
            AppWindow.TitleBar.IconShowOptions = Microsoft.UI.Windowing.IconShowOptions.HideIconAndSystemMenu;
            AppWindow.TitleBar.PreferredHeightOption = Microsoft.UI.Windowing.TitleBarHeightOption.Tall;
            NavigationView.SelectedItem = NavigationView.MenuItems[0];
            _ = Frame.Navigate(typeof(MainPage));
            ThemeHelper.Initialize();
            Closed += MainWindow_Closed;
            BBDownServer = new()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @".\Assets\BBDown.exe",
                    Arguments = $"serve -l {Constants.BBDown_Api}",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            BBDownServer.Start();
        }

        private void MainWindow_Closed(object sender, WindowEventArgs args)
        {
            if (BBDownServer != null && !BBDownServer.HasExited)
            {
                try
                {
                    BBDownServer.Kill();
                    BBDownServer.WaitForExit();  // 等待进程终止
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"关闭进程时出错: {ex.Message}");
                }
                finally
                {
                    BBDownServer.Dispose();
                }
            }
        }

        public static MainWindow current;

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                _ = Frame.Navigate(typeof(SettingPage));
            }
            else
            {
                NavigationViewItem navigationViewItem = args.SelectedItem as NavigationViewItem;
                if (Frame.CurrentSourcePageType!=null&&Frame.CurrentSourcePageType.ToString() != navigationViewItem.Tag.ToString())
                switch (navigationViewItem.Tag)
                {
                    case "Home":
                        _ = Frame.Navigate(typeof(MainPage));
                        break;
                    case "Download":
                        Frame.Navigate(typeof(DownloadPage));
                        break;
                }
            }
        }
    }
}
