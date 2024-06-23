using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Diagnostics;
using Winui3aot.Helper;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Winui3aot.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
        {
            this.InitializeComponent();
            var theme = SqliteHelper.getValue("theme");
            if (theme == "Light")
            {
                ComboBox.SelectedIndex = 0;
            }
            else if(theme=="Dark")
            {
                ComboBox.SelectedIndex = 1;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine($"ComboBox¸Ä±ä {ComboBox.SelectedIndex}");
            if (ComboBox.SelectedIndex==0)
            {
                MainWindow.toggleThemeByString("Light");
            }
            else if(ComboBox.SelectedIndex == 1)
            {
                MainWindow.toggleThemeByString("Dark");
            }
        }
    }
}
