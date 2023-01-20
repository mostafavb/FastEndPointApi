using FastEndpoints;
using FluentValidation;
using MinimalApi.Application.Features.Products.Requests;

namespace MinimalApi.FastEndpoins.Validations.Product;

public class InsertProcuctRequestValidator : Validator<InsertProductRequest>
{
    public InsertProcuctRequestValidator()
    {
        RuleFor(x => x.InsertProductDto!.Name)
            .NotEmpty()
            .WithMessage("Your name is required")
            .MaximumLength(20)
            .WithMessage("your name is too long")
            .MinimumLength(5)
            .WithMessage("your name is too short");
        RuleFor(x => x.InsertProductDto!.Description)
            .MaximumLength(100).WithMessage("description is too large");
    }
}
