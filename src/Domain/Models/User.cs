namespace Domain.Models;

public class User
{
    public Guid Id { get; init; }
    public DateTime LasUpdateTime { get; set; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Login { get; set; }
}
