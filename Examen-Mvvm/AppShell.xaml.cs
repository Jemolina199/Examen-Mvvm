using System.Diagnostics;

namespace Examen_Mvvm;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Navigated += OnNavigated;
    }

    private void OnNavigated(object? sender, ShellNavigatedEventArgs e)
    {
        Debug.WriteLine($"Navigated to: {e.Current.Location}");
    }
}
