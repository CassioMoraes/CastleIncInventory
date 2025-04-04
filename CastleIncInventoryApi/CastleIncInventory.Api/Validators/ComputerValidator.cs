using FluentValidation;
using CastleIncInventory.Domain.DataTransfer;
using CastleIncInventory.Domain.Entities;
using System.ComponentModel;
using System.Reflection;
using System.Xml;

namespace CastleIncInventory.Api.Validators
{
    public class ComputerValidator : AbstractValidator<ComputerUpsert>
    {
        public ComputerValidator()
        {
            RuleFor(e => e.PurchaseDate).NotNull().WithMessage("Purchase date is required.");
            RuleFor(e => e.SerialNumber).NotEmpty().WithMessage("Serial number is required.");
            RuleFor(e => e.WarrantyExpirationDate).NotNull().WithMessage("Warranty expiration date is required.");
            RuleFor(e => e.Specifications).NotEmpty().WithMessage("Specifications are required.");
            RuleFor(e => e.OperacionalStatus).Must(BeValidOperacionalStatus)
                .When(e => !string.IsNullOrEmpty(e.OperacionalStatus))
                .WithMessage($"Operational status is not a valid.");
        }

        private bool BeValidOperacionalStatus(string description) 
        { 
            foreach (var field in typeof(OperationalStatus).GetFields()) 
            { 
                if (field.GetCustomAttribute(typeof(DescriptionAttribute)) is DescriptionAttribute attribute) 
                { 
                    if (attribute.Description == description) 
                        return true; 
                } 
            } 
            return false; 
        }
    }
}
