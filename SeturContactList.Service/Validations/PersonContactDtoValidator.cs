using FluentValidation;
using SeturContactList.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Service.Validations
{
    public class PersonContactDtoValidator : AbstractValidator<PersonContactDto>
    {
        public PersonContactDtoValidator()
        {

            RuleFor(x => x.Phone).MaximumLength(50).WithMessage("{PropertyName} max length should be 50");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("{PropertyName} max length should be 50");
            RuleFor(x => x.City).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.City).MaximumLength(50).WithMessage("{PropertyName} max length should be 50");
            RuleFor(x => x.Town).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Town).MaximumLength(50).WithMessage("{PropertyName} max length should be 50");
            RuleFor(x => x.Address).MaximumLength(500).WithMessage("{PropertyName} max length should be 500");
            RuleFor(x => x.Info).MaximumLength(500).WithMessage("{PropertyName} max length should be 500");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.PersonId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }


    }
}
