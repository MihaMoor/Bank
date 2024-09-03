using Domain.Models;
using Infrastructure;
using System.Windows;
using System.Windows.Controls;

namespace BankWpfWindow.Pages;

/// <summary>
/// Interaction logic for AccauntSettings.xaml
/// </summary>
public partial class AccauntSettings : Page
{
    private Context _context = new();

    public AccauntSettings()
    {
        InitializeComponent();
        FillFields();
    }

    private void FillFields()
    {
        User user = UserManager.User;
        IdElement.Text = user.Id.ToString();
        FirstNameElement.Text = user.FirstName;
        SecondNameElement.Text = user.LastName;
        LoginElement.Text = user.Login;
        PasswordElement.Password = user.Password;
        MonthlyFinanceElement.Text = user.MonthlyFinance.ToString();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        User user = new()
        {
            FirstName = FirstNameElement.Text,
            LastName = SecondNameElement.Text,
            MonthlyFinance = double.Parse(MonthlyFinanceElement.Text),
            LastUpdateTime = DateTime.Now,
            Login = LoginElement.Text,
            Password = PasswordElement.Password.ToString(),
            Id = string.IsNullOrWhiteSpace(IdElement.Text)
                ? Guid.NewGuid()
                : Guid.Parse(IdElement.Text),
        };

        _context.Add(user);
        _context.SaveChanges();
    }

    private void Back_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}
