using AppFinanceiro.Core.Interfaces;
using AppFinanceiro.Views.Transaction;

namespace AppFinanceiro
{
    public partial class App : Application
    {

        public App(ITransactionRepository transactionRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TransactionList(transactionRepository));
        }
    }
}
