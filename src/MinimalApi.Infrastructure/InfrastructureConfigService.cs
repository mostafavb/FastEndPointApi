using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Application.Contracts.Contracts.Infrastructure;
using MinimalApi.Infrastructure.Email;
using System.Net;

namespace MinimalApi.Infrastructure;
public static class InfrastructureConfigService
{
    public static IServiceCollection InfrastructureServicesRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IEmailSender, EmailSender>();

        services.AddFluentEmail(configuration.GetValue<string>("EmailSettings:Email"),"Samsungs's Customer Service")
        .AddSmtpSender(new System.Net.Mail.SmtpClient()
        {

            Port = configuration.GetValue<int>("EmailSettings:Port"),
            Host = configuration.GetValue<string>("EmailSettings:Host") ?? "smtp.gmail.com",
            EnableSsl = true,
            DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(configuration.GetValue<string>("EmailSettings:User"),
                                                configuration.GetValue<string>("EmailSettings:Password")),
        });
        return services;
    }
}
