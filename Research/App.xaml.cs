using System.Globalization;
using Research.DB;

namespace Research;

public partial class App : Application
{
    private readonly IRepository _repository;

    public App(IRepository repository)
    {
        CultureInfo culture = new CultureInfo("fa-Ir");
//set Persian option to specified culture
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        
        InitializeComponent();
        _repository = repository;
        MainPage = new AppShell();
    }
}