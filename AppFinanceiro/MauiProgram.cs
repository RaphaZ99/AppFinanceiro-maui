using AppFinanceiro.Core.Interfaces;
using AppFinanceiro.Dal.Context;
using AppFinanceiro.Dal.Context.Interfaces;
using AppFinanceiro.Dal.Repositories;
using AppFinanceiro.Views.Transaction;
using LiteDB;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace AppFinanceiro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).RegisterDatabaseAndRepositories().RegisterViews();

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

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<TransactionAdd>();
            mauiAppBuilder.Services.AddTransient<TransactionEdit>();
            mauiAppBuilder.Services.AddTransient<TransactionList>();            

            return mauiAppBuilder;
        }
    }
}
