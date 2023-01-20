using FastEndpoints;
using FastEndpoints.ClientGen;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application;
using MinimalApi.Application.Features.Products.Requests;
using MinimalApi.Data;
using MinimalApi.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddFastEndpoints(option =>
    option.Assemblies = new[] { typeof(InsertProductRequest).Assembly}
);
builder.Services.DataServicesRegistreration();
builder.Services.ApplicationServicesRegistration();
builder.Services.InfrastructureServicesRegistration(builder.Configuration);
builder.Services.AddSwaggerDoc(s =>
{
    s.DocumentName = "v1"; // must match what's being passed in to the map methods below   
    
}, shortSchemaNames: true);

builder.Host.UseSerilog((_, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(builder.Configuration)
);

var app = builder.Build();

app.UseFastEndpoints(c =>
{
    c.Errors.ResponseBuilder = (failures, ctx, statusCode) =>
    {
        return new ValidationProblemDetails(
            failures.GroupBy(f => f.PropertyName)
                    .ToDictionary(
                        keySelector: e => e.Key,
                        elementSelector: e => e.Select(m => m.ErrorMessage).ToArray()))
        {
            Type = "MVB",
            Title = "One or more validation errors occurred.",
            Status = statusCode,
            Instance = ctx.Request.Path,
            Extensions = { { "traceId", ctx.TraceIdentifier } }
        };
    };
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.UseDefaultExceptionHandler(); //add this

await app.GenerateClientsAndExitAsync(
    documentName: "v1", //must match doc name above
    destinationPath: $"{Directory.GetCurrentDirectory().Trim().Replace(".FastEndpoins", ".UI")}\\Services\\DataClient",    
    csSettings: (c => 
    { 
        c.GenerateClientClasses = true;
        c.GenerateClientInterfaces=true; 
        c.ClassName = "ApiClient";
        c.CSharpGeneratorSettings.Namespace = "MnimalApi.UI.Services.DataClient"; }),
    tsSettings: null
    );

app.UseHttpsRedirection();

app.Run();