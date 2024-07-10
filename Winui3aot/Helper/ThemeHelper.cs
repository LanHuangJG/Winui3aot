using System.Diagnostics;

using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace Winui3aot.Helper
{
    public class ThemeHelper
    {
        private static readonly MainWindow current = MainWindow.current;

        public static void Initialize()
        {
            InitializeTheme();
            InitializeBackdrop();
        }

        //主题

        public static void InitializeTheme()
        {
            if (current.Content is FrameworkElement rootElement)
            {
                string theme = SqliteHelper.getValue(Constants.THEME);
                if (theme == "Light")
                {
                    ToggleThemeLight(rootElement);
                }
                else if (theme == "Dark")
                {
                    ToggleThemeDark(rootElement);
                }
            }
        }

        public static void ToggleThemeLight(FrameworkElement rootElement)
        {
            rootElement.RequestedTheme = ElementTheme.Light;
            current.AppWindow.TitleBar.BackgroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ForegroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ButtonForegroundColor = Colors.Black;
            SqliteHelper.insertOrUpdate(Constants.THEME, rootElement.ActualTheme.ToString());
        }

        public static void ToggleThemeDark(FrameworkElement rootElement)
        {
            rootElement.RequestedTheme = ElementTheme.Dark;
            current.AppWindow.TitleBar.BackgroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ForegroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            current.AppWindow.TitleBar.ButtonForegroundColor = Colors.White;
            SqliteHelper.insertOrUpdate(Constants.THEME, rootElement.ActualTheme.ToString());
        }
        public static void ToggleTheme()
        {
            if (current.Content is FrameworkElement rootElement)
            {
                bool isThemeLight = rootElement.ActualTheme is ElementTheme.Light;
                if (isThemeLight)
                {
                    ToggleThemeDark(rootElement);
                }
                else
                {
                    ToggleThemeLight(rootElement);
                }
            }
        }

        public static void ToggleThemeByString(string theme)
        {
            if (current.Content is FrameworkElement rootElement)
            {
                bool isThemeLight = theme == "Light";
                if (isThemeLight&&rootElement.ActualTheme is ElementTheme.Dark)
                {
                    ToggleThemeLight(rootElement);
                }
                else if(!isThemeLight && rootElement.ActualTheme is ElementTheme.Light)
                {
                    ToggleThemeDark(rootElement);
                }
            }
        }

        //材质

        public static void InitializeBackdrop()
        {
            string backdrop = SqliteHelper.getValue(Constants.BACKDROP);
            if (backdrop == "Mica")
            {
                current.SystemBackdrop = new MicaBackdrop();
            }
            else if (backdrop == "DesktopAcrylic")
            {
                current.SystemBackdrop = new DesktopAcrylicBackdrop();
            }
        }

        public static void SwitchToMica()
        {
            if (current.SystemBackdrop is not MicaBackdrop)
            {
                SqliteHelper.insertOrUpdate(Constants.BACKDROP, "Mica");
                current.SystemBackdrop = new MicaBackdrop();
            }
            Debug.WriteLine(current.SystemBackdrop.ToString());

        }
        public static void SwitchToArcylic()
        {
            if (current.SystemBackdrop is not DesktopAcrylicBackdrop)
            {
                SqliteHelper.insertOrUpdate(Constants.BACKDROP, "DesktopAcrylic");
                current.SystemBackdrop = new DesktopAcrylicBackdrop();
            }
            Debug.WriteLine(current.SystemBackdrop.ToString());

        }


    }
}
