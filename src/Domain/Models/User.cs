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

    public void AddDailyFinance()
    {
        if (LastUpdateTime == default)
        {
            Balance += GetDailyFinance();
        }
        else
        {
            TimeSpan daysCount = DateTime.Now - LastUpdateTime;
            Balance += GetDailyFinance() * Math.Round(daysCount.TotalDays, 0);
        }

        Balance = Math.Round(Balance, 2);
        LastUpdateTime = DateTime.Now;
    }

    private double GetDailyFinance()
        => MonthlyFinance / DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
}
