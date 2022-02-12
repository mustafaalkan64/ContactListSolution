using FluentValidation;
using SeturContactList.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Service.Validations
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Company).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("{PropertyName} max length should be 50");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("{PropertyName} max length should be 50");
            RuleFor(x => x.Company).MaximumLength(150).WithMessage("{PropertyName} max length should be 150");

        }


    }
}
