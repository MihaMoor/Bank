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
}
