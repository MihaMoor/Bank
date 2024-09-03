using Domain.Models;
using Infrastructure;
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
        Context context = new Context();
        User? user = context.Users.FirstOrDefault(x => x.Login == LoginElement.Text && x.Password == PasswordElement.Password.ToString());

        if (user == null)
        {
            MessageBox.Show("Такого пользователя не существует!", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        UserManager.SetUser(user);
        UserManager.AddDailyFinance();

        context.Users.Update(user);
        context.SaveChanges();

        NavigationService.Navigate(new Main());
    }

    private void RegistrationElement_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Registration());
    }
}
