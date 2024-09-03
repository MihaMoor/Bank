namespace Domain.Models;

public class User
{
    public Guid Id { get; init; }
    public DateTime LastUpdateTime { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public double MonthlyFinance { get; set; } = 1;
    public double Balance { get; set; } = 0;
    public IList<BalanceHistory> BalanceHistory { get; set; } = null!;

    public void AddDailyFinance()
    {
        if (LastUpdateTime == default)
        {
            Balance += GetDailyFinance();
        }
        else
        {
            TimeSpan daysCount = DateTime.UtcNow - LastUpdateTime;
            Balance += GetDailyFinance() * Math.Round(daysCount.TotalDays, 0);
        }

        Balance = Math.Round(Balance, 2);
        LastUpdateTime = DateTime.UtcNow;
    }

    private double GetDailyFinance()
        => MonthlyFinance / DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month);

    public void AddCoast(double amount)
    {
        if (amount < 0)
            return;

        Balance -= amount;
    }
}
