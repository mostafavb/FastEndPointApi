namespace MinimalApi.Application.Models;
public class BaseCommandResponse<T>
{
    public T? ReturnValue { get; set; }
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
    public List<string> Errors { get; set; } = new();
   
}
