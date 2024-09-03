using BankWpfWindow.Models;
using Domain.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankWpfWindow.Pages;

/// <summary>
/// Interaction logic for Main.xaml
/// </summary>
public partial class Main : Page
{
    private List<BalanceHistoryViewModel> _history = [];

    public Main()
    {
        InitializeComponent();
        Balance.Content = UserManager.User.Balance;
        UpdateBalanceHistory();
    }

    private void UpdateBalanceHistory()
    {
        foreach (var history in UserManager.User.BalanceHistory)
        {
            BalanceHistoryViewModel historyViewModel = new()
            {
                Id = history.Id,
                OldBalance = history.OldBalance,
                CurrentBalance = history.CurrentBalance,
                UpdateDate = history.UpdateDate,
            };
            _history.Add(historyViewModel);
        }
        _history.Sort();

        BalanceHistoryElement.ItemsSource = null;
        BalanceHistoryElement.ItemsSource = _history;
    }

    private void AddFinance_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddCost_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(Coast.Text, out double amount))
        {
            BalanceHistory history = new()
            {
                UpdateDate = DateTime.UtcNow,
                User = UserManager.User,
                OldBalance = UserManager.User.Balance,
            };
            UserManager.User.AddCoast(amount);
            history.CurrentBalance = UserManager.User.Balance;
            UserManager.User.BalanceHistory.Add(history);

            UserManager.Context.Update(UserManager.User);
            UserManager.Context.SaveChanges();

            UpdateBalanceHistory();
        }
        else
        {
            MessageBox.Show(
                "Некорректно введено значение в поле 'Добавить расход'",
                "Ошибка ввода значения",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        CleanCoastField();
        Balance.Content = UserManager.User.Balance;
    }

    private void CleanCoast_Click(object sender, RoutedEventArgs e)
    {
        CleanCoastField();
    }

    private void Settings_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new AccauntSettings());
    }

    private void CleanCoastField()
        => Coast.Text = string.Empty;

    private void Logout_Click(object sender, RoutedEventArgs e)
    {
        UserManager.RefreshManager();
        NavigationService.Navigate(new Authorization());
    }

    private void EnterKeyAddCoast(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            AddCost_Click(sender, e);
        }
    }
}
