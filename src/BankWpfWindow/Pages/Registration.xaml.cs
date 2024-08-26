using Domain.Models;
using System.Windows.Controls;

namespace BankWpfWindow.Pages;

/// <summary>
/// Interaction logic for Registration.xaml
/// </summary>
public partial class Registration : Page
{
    public Registration()
    {
        InitializeComponent();
    }

    private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        User user = new()
        {
            FirstName = FirstNameElement.Text,
            LastName = SecondNameElement.Text,
            Login = LoginElement.Text,
            Password = PasswordElement.Text,
            MonthlyFinance = double.Parse(MonthlyFinanceElement.Text),
        };

        UserManager.Context.Users.Add(user);
        UserManager.Context.SaveChanges();

        NavigationService.Navigate(new Authorization());
    }

    private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        NavigationService.Navigate(new Authorization());
    }
}
