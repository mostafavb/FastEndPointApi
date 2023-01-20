using FluentEmail.Core;
using Microsoft.Extensions.Options;
using MinimalApi.Application.Contracts.Contracts.Infrastructure;

namespace MinimalApi.Infrastructure.Email;
public class EmailSender : IEmailSender
{
    private readonly IFluentEmail _email;

    
    public EmailSender(IFluentEmail email)
    {
       _email = email;
    }

    public async Task<bool> SendEmail(Application.Models.Email email)
    {      
        var result = await _email
            .To(email.To)
            .Subject(email.Subject)
            .Body(email.Body).SendAsync();
        return result.Successful;
    }
}
