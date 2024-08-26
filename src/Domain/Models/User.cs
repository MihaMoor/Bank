namespace Domain.Models;

public class User
{
    public Guid Id { get; init; }
    public DateTime LasUpdateTime { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public double MonthlyFinance { get; set; } = 1;
}
