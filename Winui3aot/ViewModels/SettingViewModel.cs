using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Controls;
using Winui3aot.Helper;

namespace Winui3aot.ViewModels
{
    public partial class SettingViewModel : ObservableObject
    {
        [ObservableProperty]
        public int themeSelectIndex;

        [ObservableProperty]
        public int backdropSelectIndex;

        [ObservableProperty]
        public string downloadPath;

        public SettingViewModel()
        {
            string theme = SqliteHelper.getValue("theme");
            string downloadStoragePath = SqliteHelper.getValue("downloadPath");
            if (theme == "Light")
            {
                themeSelectIndex = 0;
            }
            else if (theme == "Dark")
            {
                themeSelectIndex = 1;
            }

            string backdrop = SqliteHelper.getValue("backdrop");
            if (backdrop == "Mica")
            {
                backdropSelectIndex = 0;
            }
            else if (backdrop == "DesktopAcrylic")
            {
                backdropSelectIndex = 1;
            }
            if (downloadStoragePath == null)
            {
                downloadPath = "指定视频保存的目录";
            }
            else
            {
                downloadPath = downloadStoragePath;
            }
        }
        public void setDownloadPath(string path)
        {
            DownloadPath = path;
            SqliteHelper.insertOrUpdate("downloadPath", path);
        }
    }
}
