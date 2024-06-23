using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winui3aot.Helper
{
    public class ThemeHelper
    {
        public static MainWindow current = MainWindow.current;
        public static void switchToMica()
        {
            current.SystemBackdrop = new Microsoft.UI.Xaml.Media.MicaBackdrop();
        }
        public static void switchToArcylic()
        {
            current.SystemBackdrop = new Microsoft.UI.Xaml.Media.DesktopAcrylicBackdrop();
        }
    }
}
