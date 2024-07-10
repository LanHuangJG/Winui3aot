using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Windows.ApplicationModel.DataTransfer;

using Winui3aot.Helper;
namespace Winui3aot.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {

        }
        [ObservableProperty]
        public string output = "输出信息";

        [ObservableProperty]
        public string videoUrl = "";

        [ObservableProperty]
        public double loadingState = 0;
        public void Start()
        {
            DownloadVideo(VideoUrl);
        }
        [RelayCommand]
        private async Task PasteClipBoard()
        {
            var package = Clipboard.GetContent();
            if (package.Contains(StandardDataFormats.Text))
            {
                var text = await package.GetTextAsync();
                App.dispatcherQueue.TryEnqueue(() =>
                {
                    VideoUrl = text;
                });
            }
        }
        private void DownloadVideo(string Url)
        {
            
            _ = Task.Run(async () =>
            {
                var response = await BBDownHelper.AddTaskAsync(Url);
                Debug.WriteLine(response);
            });
        }

    }
}
