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
}