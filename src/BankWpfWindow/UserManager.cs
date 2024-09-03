using Domain.Models;
using Infrastructure;

namespace BankWpfWindow;

public static class UserManager
{
    public static User User { get; private set; } = null!;
    public static Context Context { get; private set; } = new();

    private static bool IsAddDailyFinance { get; set; } = false;

    public static void SetUser(User user)
    {
        if (user == null)
            return;

        if (User != null)
            return;

        User = user;
    }

    public static void AddDailyFinance()
    {
        if (!IsAddDailyFinance)
        {
            User.AddDailyFinance();
            IsAddDailyFinance = true;
        }
    }

    public static void RefreshManager()
    {
        User = null!;
        Context = new();
    }
}
