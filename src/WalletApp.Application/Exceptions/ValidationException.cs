using FluentValidation.Results;

namespace WalletApp.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> failures)
    {
        Errors = failures.Select(f => f.ErrorMessage).ToList();
    }
}