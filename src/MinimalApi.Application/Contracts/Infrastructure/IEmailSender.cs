using MinimalApi.Application.Models;

namespace MinimalApi.Application.Contracts.Contracts.Infrastructure;
public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}
