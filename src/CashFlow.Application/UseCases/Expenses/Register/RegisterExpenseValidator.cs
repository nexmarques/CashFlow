using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("The title is required");
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("The Amount must be greater than zero");
        RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses can't be for the future");
        RuleFor(x => x.PaymentType).IsInEnum().WithMessage("The paymentType is invalid. Try again and use another option");
    }
}
