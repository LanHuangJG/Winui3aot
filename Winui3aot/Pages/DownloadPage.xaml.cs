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
                Title = "提示",
                Content = "您真的确定删除这个视频吗,它将离开很久...",
                PrimaryButtonText = "确定",
                DefaultButton = ContentDialogButton.Primary,
                SecondaryButtonText = "取消",
                XamlRoot = XamlRoot
            };
            var result = await dialog.ShowAsync();
        }
    }
}
