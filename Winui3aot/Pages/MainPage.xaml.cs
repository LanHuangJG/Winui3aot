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
    }
}
