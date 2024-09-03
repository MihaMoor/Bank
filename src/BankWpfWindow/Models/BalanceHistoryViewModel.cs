namespace BankWpfWindow.Models;

internal class BalanceHistoryViewModel : IComparable<BalanceHistoryViewModel>
{
    public Guid Id { get; set; }
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    public double OldBalance { get; set; } = 0;
    public double CurrentBalance { get; set; } = 0;

    public int CompareTo(BalanceHistoryViewModel? other)
    {
        if (this == null || other == null) return 0;
        if (UpdateDate < other.UpdateDate) return 1;
        if (UpdateDate > other.UpdateDate) return -1;
        return 0;
    }
}
