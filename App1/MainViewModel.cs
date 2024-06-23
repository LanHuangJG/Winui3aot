using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App1
{
    public partial class MainViewModel:ObservableObject
    {

        [RelayCommand]
        private void Start()
        {
            Debug.WriteLine("hello world");
        }
    }
}
