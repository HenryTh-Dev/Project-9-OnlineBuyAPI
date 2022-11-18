using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuy.Application.DTOs.Validations 
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("A name must be informed.");

            RuleFor(p => p.Ssn)
                .NotEmpty()
                .NotNull()
                .WithMessage("A SSN must be informed.");

            RuleFor(p => p.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("A phone must be informed.");
        }
    }
}
