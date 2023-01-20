using FastEndpoints;
using FluentValidation;
using MinimalApi.FastEndpoins.DTOs.Month.Requests;

namespace MinimalApi.FastEndpoins.Validations.Month;

public class MonthIndexRequestValidator : Validator<MonthIndexRequest>
{
	public MonthIndexRequestValidator()
	{
		RuleFor(x => x.MonthIndex)
			.GreaterThanOrEqualTo(0).WithMessage("the input amount must be greate than or equal 0")
			.LessThanOrEqualTo(12).WithMessage("the input number must be smaller or equal 12");
	}
}
