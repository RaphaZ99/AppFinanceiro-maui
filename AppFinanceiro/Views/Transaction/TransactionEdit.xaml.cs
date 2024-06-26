using AppFinanceiro.Application.Services.Interfaces;
using CommunityToolkit.Mvvm.Messaging;

namespace AppFinanceiro.Views.Transaction;

public partial class TransactionEdit : ContentPage
{
    private readonly ITransactionService _service;
    private Core.Domain.Transaction _transaction;
    public TransactionEdit(ITransactionService service)
    {
        InitializeComponent();
        _service = service;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void OnButtonClicked_Save(object sender, EventArgs e)
    {
        if (!isValidData())
            return;

        AppFinanceiro.Core.Domain.Transaction transaction = new AppFinanceiro.Core.Domain.Transaction
        {
            Date = DatePickerDate.Date,
            Name = EntryName.Text,
            Value = decimal.Parse(EntryValue.Text),
            TransactionType = RadioIncome.IsChecked ? Core.Enums.TransactionType.Income : Core.Enums.TransactionType.Expenses

        };

        await _service.Update(transaction);

        WeakReferenceMessenger.Default.Send<string>(string.Empty);

        await Navigation.PopModalAsync();

    }

    public void SetTransactionToEdit(Core.Domain.Transaction transaction)
    {
        _transaction = transaction;

        RadioIncome.IsChecked = transaction.TransactionType == Core.Enums.TransactionType.Income ? true : false;
        RadioExpense.IsChecked = !RadioIncome.IsChecked ? true : false;
        EntryName.Text = transaction.Name;
        DatePickerDate.Date = transaction.Date.Date;
        EntryValue.Text = transaction.Value.ToString();
    }

    private bool isValidData()
    {

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            LabelError.IsVisible = true;
            LabelError.Text = "O campo Nome deve ser preenchido";
            return false;
        }

        if (string.IsNullOrEmpty(EntryValue.Text) || string.IsNullOrWhiteSpace(EntryValue.Text)
            || !double.TryParse(EntryValue.Text, out double result))
        {
            LabelError.IsVisible = true;
            LabelError.Text = "O campo valor deve ser preenchido e ter apenas n�meros";

            return false;
        }

        return true;
    }

    private void TapGestureRecognizerTaped_ToClose(object sender, TappedEventArgs e)
    {

    }
}