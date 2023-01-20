namespace MnimalApi;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}