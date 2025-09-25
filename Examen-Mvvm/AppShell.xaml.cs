using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace Examen_Mvvm
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Example: Register route for navigation
            // Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));

            // Example: Handle navigation events
            Navigated += OnNavigated;
        }

        private void OnNavigated(object? sender, ShellNavigatedEventArgs e)
        {
            // Example: Log navigation or handle analytics
            Debug.WriteLine($"Navigated to: {e.Current.Location}");
        }

        // If you use dependency injection, inject services here
        // public AppShell(IMyService myService) { ... }
    }
}
