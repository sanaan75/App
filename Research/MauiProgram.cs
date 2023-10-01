using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCore.AutoRegisterDi;
using Persistence;
using AppContext = Persistence.AppContext;

namespace Research;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.RegisterAssemblyPublicNonGenericClasses(GetAssembliesToBeRegisteredInIocContainer())
            .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddDbContext<AppContext>(opts => { opts.UseSqlite(DbSettings.Connection); });
        return builder.Build();

        Assembly[] GetAssembliesToBeRegisteredInIocContainer()
        {
            return new[]
            {
                typeof(PersistenceDummy).Assembly,
            };
        }
    }
}
//C:\Users\sanaa\AppData\Local\Packages\com.companyname.research_9zz4h110yvjzm\LocalState