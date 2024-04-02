using AppFinanceiro.Application.Services.Interfaces;
using AppFinanceiro.Views.Transaction;

namespace AppFinanceiro
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App(ITransactionService service)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TransactionList(service));
        }
    }
}
