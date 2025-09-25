using Microsoft.Maui.Controls;

namespace Examen_Mvvm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
#if DEBUG
            // This will prevent a build error if the XAML file is missing during early development.
#else
            InitializeComponent();
#endif
        }
    }
}