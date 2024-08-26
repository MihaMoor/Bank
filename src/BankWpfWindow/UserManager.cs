using Domain.Models;
using Infrastructure;

namespace BankWpfWindow;

public static class UserManager
{
    public static User User { get; private set; } = null!;
    public static Context Context { get; } = new();

    public static void SetUser(User user)
    {
        if (user == null)
            return;

        if (User != null)
            return;

        User = user;
    }
}
