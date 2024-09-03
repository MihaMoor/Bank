using Domain.Models;
using System.Windows;
using System.Windows.Controls;

namespace BankWpfWindow.Pages;

/// <summary>
/// Interaction logic for AccauntSettings.xaml
/// </summary>
public partial class AccauntSettings : Page
{
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
        BalanceElement.Text = user.Balance.ToString();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        double oldBalance = UserManager.User.Balance;

        UserManager.User.FirstName = FirstNameElement.Text;
        UserManager.User.LastName = SecondNameElement.Text;
        UserManager.User.MonthlyFinance = double.Parse(MonthlyFinanceElement.Text);
        UserManager.User.LastUpdateTime = DateTime.UtcNow;
        UserManager.User.Login = LoginElement.Text;
        UserManager.User.Password = PasswordElement.Password.ToString();
        UserManager.User.Balance = double.Parse(BalanceElement.Text);

        if (Math.Abs(oldBalance - UserManager.User.Balance) > double.Epsilon)
        {
            UserManager.User.BalanceHistory.Add(new BalanceHistory()
            {
                UpdateDate = DateTime.UtcNow,
                User = UserManager.User,
                OldBalance = oldBalance,
                CurrentBalance = UserManager.User.Balance,
            });
        }

        UserManager.Context.Update(UserManager.User);
        UserManager.Context.SaveChanges();

        NavigationService.Navigate(new Main());
    }

    private void Back_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}
