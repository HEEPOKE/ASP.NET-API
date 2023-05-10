namespace app.Models.Response;

public class UserMessageResponse
{
    public string? Message { get; set; }
    public IEnumerable<User>? Data { get; set; }
}
