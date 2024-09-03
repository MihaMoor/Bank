namespace Domain.Models;

public class BalanceHistory
{
    public Guid Id { get; set; }
    public User User { get; set; } = null!;
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    public double OldBalance { get; set; } = 0;
    public double CurrentBalance { get; set; } = 0;
}
