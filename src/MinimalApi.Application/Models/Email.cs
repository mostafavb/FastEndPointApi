namespace MinimalApi.Application.Models;
public class Email
{
    public string? To { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
