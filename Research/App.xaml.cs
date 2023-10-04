using System.Globalization;

namespace Research;

public partial class App : Application
{
    public App()
    {
        CultureInfo culture = new CultureInfo("fa-Ir");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;


        InitializeComponent();
        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var windows = base.CreateWindow(activationState);
        windows.Height = 800;
        windows.Width = 400;
        return windows;
    }
}