using AppFinanceiro.Views.Transaction;

namespace AppFinanceiro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TransactionList();
        }
    }
}
