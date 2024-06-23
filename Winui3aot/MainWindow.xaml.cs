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
        public MainWindow()
        {
            current = this;
            var theme = SqliteHelper.getValue("theme");
            if (current.Content is FrameworkElement rootElement)
            {
                if (theme == "Light")
                {
                    toggleThemeLight(rootElement);
                }
                else if (theme == "Dark")
                {
                    toggleThemeDark(rootElement);
                }
            }
            InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            this.CenterOnScreen();
            AppWindow.TitleBar.IconShowOptions = Microsoft.UI.Windowing.IconShowOptions.HideIconAndSystemMenu;
            AppWindow.TitleBar.PreferredHeightOption = Microsoft.UI.Windowing.TitleBarHeightOption.Tall;
            AppWindow.DefaultTitleBarShouldMatchAppModeTheme = true;
            NavigationView.SelectedItem = NavigationView.MenuItems[0];
            _ = Frame.Navigate(typeof(MainPage));

        }
        public static MainWindow current;

        public static void toggleThemeLight(FrameworkElement rootElement)
        {
            rootElement.RequestedTheme = ElementTheme.Light;
            current.AppWindow.TitleBar.BackgroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ForegroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ButtonForegroundColor = Colors.Black;
            SqliteHelper.insertOrUpdate("theme", rootElement.ActualTheme.ToString());
        }

        public static void toggleThemeDark(FrameworkElement rootElement)
        {   
            rootElement.RequestedTheme = ElementTheme.Dark;
            current.AppWindow.TitleBar.BackgroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ForegroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ButtonForegroundColor = Colors.White;
            SqliteHelper.insertOrUpdate("theme", rootElement.ActualTheme.ToString());
        }
        public static void toggleTheme()
        {
            if (current.Content is FrameworkElement rootElement)
            {
                bool isThemeLight = rootElement.ActualTheme is ElementTheme.Light;
                if (isThemeLight)
                {
                    toggleThemeDark(rootElement);
                }
                else
                {
                    toggleThemeLight(rootElement);
                }
            }
        }

        public static void toggleThemeByString(string theme)
        {
            if (current.Content is FrameworkElement rootElement)
            {
                bool isThemeLight = theme == "Light";
                if (isThemeLight)
                {
                    toggleThemeLight(rootElement);
                }
                else
                {
                    toggleThemeDark(rootElement);
                }
            }
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                _ = Frame.Navigate(typeof(SettingPage));
            }
            else
            {
                NavigationViewItem navigationViewItem = args.SelectedItem as NavigationViewItem;
                switch (navigationViewItem.Tag)
                {
                    case "Home":
                        _ = Frame.Navigate(typeof(MainPage));
                        break;
                }
            }
        }
    }
}
