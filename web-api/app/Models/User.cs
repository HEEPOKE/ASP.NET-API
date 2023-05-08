namespace app.Models;

public enum UserRole
{
    Admin,
    User
}

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Tel { get; set; }
    public UserRole Role { get; set; }
}
