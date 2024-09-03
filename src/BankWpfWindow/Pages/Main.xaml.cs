using System.Windows;
using System.Windows.Controls;

namespace BankWpfWindow.Pages;

/// <summary>
/// Interaction logic for Main.xaml
/// </summary>
public partial class Main : Page
{
    public Main()
    {
        InitializeComponent();
        Balance.Content = UserManager.User.Balance;
    }

    private void AddFinance_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddCost_Click(object sender, RoutedEventArgs e)
    {
        CleanCoastField();
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
        NavigationService.Navigate(new Authorization());
    }
}
