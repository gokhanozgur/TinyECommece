using System.Data;
using FluentValidation;
using TinyECommerce.Application.ViewModels.Products;

namespace TinyECommerce.Application.Validators;

public class CreateProductValidator: AbstractValidator<VM_Create_Product>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .Length(2, 255)
                .WithMessage("The name field cannot be empty.");
        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
                .WithMessage("The name field cannot be empty.")
            .GreaterThanOrEqualTo(0)
                .WithMessage("The price field must be greater than or equal to zero(0).");
        RuleFor(p => p.Stock)
            .NotEmpty()
            .NotNull()
                .WithMessage("The name field cannot be empty.")
            .GreaterThanOrEqualTo(0)
                .WithMessage("The stock field must be greater than or equal to zero(0).");
    }
}