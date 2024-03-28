using AppFinanceiro.Core.Interfaces;
using AppFinanceiro.Dal.Context;
using AppFinanceiro.Dal.Context.Interfaces;
using AppFinanceiro.Dal.Repositories;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace AppFinanceiro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).RegisterDatabaseAndRepositories();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterDatabaseAndRepositories(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IDbContext>(_ => new LiteDbContext(AppSettings.DatabasePath));
            mauiAppBuilder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

            return mauiAppBuilder;
        }
    }
}
