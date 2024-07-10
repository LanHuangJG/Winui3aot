using System;
using System.Diagnostics;

using Microsoft.UI.Xaml.Controls;

using Windows.Storage;
using Windows.Storage.Pickers;

using Winui3aot.Helper;
using Winui3aot.ViewModels;


namespace Winui3aot.Pages
{

    public sealed partial class SettingPage : Page
    {
        public SettingViewModel ViewModel = new();
        public SettingPage()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            if (combobox.SelectedIndex == 0)
            {
                ThemeHelper.ToggleThemeByString("Light");
            }
            else if (combobox.SelectedIndex == 1)
            {
                ThemeHelper.ToggleThemeByString("Dark");
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            if (combobox.SelectedIndex == 0)
            {
                ThemeHelper.SwitchToMica();
            }
            else if (combobox.SelectedIndex == 1)
            {
                ThemeHelper.SwitchToArcylic();
            }
        }

        private async void SelectStoragePathAsync(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            FolderPicker openPicker = new();
            WinUIEx.WindowEx window = App.m_window;
            nint hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);
            openPicker.CommitButtonText = "È·¶¨";
            openPicker.ViewMode = PickerViewMode.List;
            openPicker.SuggestedStartLocation = PickerLocationId.Downloads;
            openPicker.FileTypeFilter.Add("*");
            StorageFolder folder = await openPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                ViewModel.setDownloadPath(folder.Path);
            }
            else
            {
                Debug.WriteLine("Operation cancelled.");
            }

        }
    }
}
