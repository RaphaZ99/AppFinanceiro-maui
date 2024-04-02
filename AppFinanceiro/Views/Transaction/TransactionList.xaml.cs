using AppFinanceiro.Application.Services.Interfaces;
using CommunityToolkit.Mvvm.Messaging;

namespace AppFinanceiro.Views.Transaction;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionService _service;
    private Color _initialBackgroundStateBorder;
    private string _initialNameTextBorder;

    public TransactionList(ITransactionService service)
    {
        InitializeComponent();
        _service = service;
        BindInfo();

        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            BindInfo();
        });
    }

    private async void OnButtonClicked_To_TransactionAdd(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(Handler?.MauiContext?.Services.GetService<TransactionAdd>()); ;

    }

    private async void OnButtonClicked_To_TransactionEdit(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(Handler?.MauiContext?.Services.GetService<TransactionEdit>());
    }

    private async void BindInfo()
    {
        var items = await _service.GetAll() ;
                
            CollectionViewTransactions.ItemsSource = items;

            var expense = items.Where(x => x.TransactionType == Core.Enums.TransactionType.Expenses).Sum(x => x.Value);
            var income = items.Where(x => x.TransactionType == Core.Enums.TransactionType.Income).Sum(x => x.Value);

            ValueExpense.Text = expense.ToString("C");
            ValueIncome.Text = income.ToString("C");
            ValueBalance.Text = (income - expense).ToString("C");         

    }

    private async void TapGestureRecognizer_Tapped_To_TransactionEdit(object sender, TappedEventArgs e)
    {
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer)grid.GestureRecognizers[0];

        Core.Domain.Transaction transactionToEdit = (Core.Domain.Transaction)gesture.CommandParameter;

        var transactionEditView = Handler?.MauiContext?.Services.GetService<TransactionEdit>();
        transactionEditView.SetTransactionToEdit(transactionToEdit);

        await Navigation.PushModalAsync(transactionEditView);
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await AnimationCircle((Border)sender, true);

        var result = await App.Current.MainPage.DisplayAlert("Excluir", "Tem certeza que deseja excluir?", "Sim", "Não");

        if (result)
        {
            var transaction = (Core.Domain.Transaction)e.Parameter;

           await  _service.DeleteById(transaction.Id);

            BindInfo();
        }
        else
        {
            await AnimationCircle((Border)sender, false);
        }
    }

    private async Task AnimationCircle(Border border, bool isDeleteAnimation)
    {
        var labelInfo = (Label)border.Content;

        if (isDeleteAnimation)
        {
            _initialNameTextBorder = labelInfo.Text;
            _initialBackgroundStateBorder = border.BackgroundColor;

            await border.RotateYTo(90, 500);
            border.BackgroundColor = Microsoft.Maui.Graphics.Colors.Red;
            var label = (Label)border.Content;
            label.TextColor = Microsoft.Maui.Graphics.Colors.White;
            label.Text = "X";

            await border.RotateYTo(180, 500);
        }
        else
        {
            await border.RotateYTo(90, 500);
            labelInfo.TextColor = Colors.Black;
            labelInfo.Text = _initialNameTextBorder;
            border.BackgroundColor = _initialBackgroundStateBorder;
            await border.RotateYTo(0, 500);
        }
    }
}