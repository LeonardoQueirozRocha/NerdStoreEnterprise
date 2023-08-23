using FluentValidation.Results;

namespace NSE.Identity.API.Services.Base;

public abstract class BaseService
{
    private readonly ValidationResult ValidationResult = new();

    protected void AddError(string error)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, error));
    }

    protected void AddErrors(List<string> errors)
    {
        errors.ForEach(error => AddError(error));
    }

    protected ValidationResult GetValidation() => ValidationResult;
}
