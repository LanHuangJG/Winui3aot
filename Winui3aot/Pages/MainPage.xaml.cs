using System;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using Winui3aot.ViewModels;


namespace Winui3aot.Pages
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel = new ();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartDownload(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (VideoUrl.Text == "")
            {
                var contentDialog = new ContentDialog
                {
                    Title = "��ʾ",
                    Content = "��Ƶ���Ӳ���Ϊ��.",
                    DefaultButton = ContentDialogButton.Primary,
                    PrimaryButtonText = "ȷ��",
                    XamlRoot = XamlRoot,
                    RequestedTheme = (App.m_window.Content as FrameworkElement).ActualTheme
                };
                var result = await contentDialog.ShowAsync();
            }
            else if (!VideoUrl.Text.StartsWith("https://www.bilibili.com/video"))
            {
                var contentDialog = new ContentDialog
                {
                    Title = "��ʾ",
                    Content = "��Ƶ���Ӳ���ȷ,�����ǲ��Ǹ��ƴ���.",
                    DefaultButton = ContentDialogButton.Primary,
                    PrimaryButtonText = "ȷ��",
                    XamlRoot = XamlRoot,
                    RequestedTheme = (App.m_window.Content as FrameworkElement).ActualTheme
                };
                _ = await contentDialog.ShowAsync();
            }
            else
            {
                ViewModel.Start();
            }
        }
    }
}
