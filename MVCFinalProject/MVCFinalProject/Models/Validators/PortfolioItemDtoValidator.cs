using FluentValidation;
using MVCFinalProject.Models.DTOs;

namespace MVCFinalProject.Models.Validators
{
    public class PortfolioItemDtoValidator : AbstractValidator<PortfolioItemDto>
    {
        public PortfolioItemDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.DateCreated)
                .NotEmpty().WithMessage("Date Created is required")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date Created cannot be in the future");
        }
    }
}
