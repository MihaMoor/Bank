using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace BankWpfWindow.Pages;

/// <summary>
/// Interaction logic for Authorization.xaml
/// </summary>
public partial class Authorization : Page
{
    public Authorization()
    {
        if (NavigationService != null)
            NavigationService.RemoveBackEntry();

        InitializeComponent();
    }

    private void EnterElement_Click(object sender, RoutedEventArgs e)
    {
        User? user = UserManager.Context.Users
            .Include(x => x.BalanceHistory)
            .FirstOrDefault(x => x.Login == LoginElement.Text && x.Password == PasswordElement.Password.ToString());

        if (user == null)
        {
            MessageBox.Show(
                "Такого пользователя не существует!",
                "Ошибка входа",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        UserManager.SetUser(user);
        UserManager.AddDailyFinance();

        UserManager.Context.Users.Update(user);
        UserManager.Context.SaveChanges();

        NavigationService.Navigate(new Main());
    }

    private void RegistrationElement_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Registration());
    }
}
