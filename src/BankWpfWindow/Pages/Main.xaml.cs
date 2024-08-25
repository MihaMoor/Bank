using Domain;
using System.Windows;
using System.Windows.Controls;

namespace BankWpfWindow;

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
        AddCoast.Add(DateTime.Now, 1000);
    }

    private void AddCost_Click(object sender, RoutedEventArgs e)
    {

    }

    private void CleanCoast_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Settings_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new AccauntSettings());
    }
}
