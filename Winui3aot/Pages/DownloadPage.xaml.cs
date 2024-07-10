using System;
using System.Diagnostics;

using Microsoft.UI.Xaml.Controls;

using Winui3aot.Helper;
using Winui3aot.Model;
using Winui3aot.ViewModels;



namespace Winui3aot.Pages
{

    public sealed partial class DownloadPage : Page
    {
        public DownloadViewMdoel ViewMdoel = new();
        public DownloadPage()
        {
            InitializeComponent();
        }

        private void OpenDownloadDirectory(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var downloadPath = SqliteHelper.getValue(Constants.DOWNLOADPATH);
            Process.Start("explorer.exe", downloadPath);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var videoModel = e.ClickedItem as VideoModel;
            Process.Start("explorer.exe", videoModel.path);
        }

        private async void DeleteVideo(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var videoModel = (sender as Button).DataContext as VideoModel;
            var dialog = new ContentDialog
            {
                Title = "��ʾ",
                Content = "�����ȷ��ɾ�������Ƶ��,�����뿪�ܾ�...",
                PrimaryButtonText = "ȷ��",
                DefaultButton = ContentDialogButton.Primary,
                SecondaryButtonText = "ȡ��",
                XamlRoot = XamlRoot
            };
            var result = await dialog.ShowAsync();
        }
    }
}
