using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

using Winui3aot.Helper;
using Winui3aot.Model;

namespace Winui3aot.ViewModels
{
    public class DownloadViewMdoel : ObservableObject
    {

        public ObservableCollection<VideoModel> VideoList = new();

        public DownloadViewMdoel()
        {
            VideoList.Clear();
            var downloadPath = SqliteHelper.getValue(Constants.DOWNLOADPATH);
            foreach (var item in Directory.EnumerateFiles(downloadPath))
            {
                VideoList.Add(new VideoModel(Path.GetFileName(item),item));
            }
        }

    }
}
