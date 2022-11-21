using Application.CQRS.DTOs.Admin;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Admin
{
    public class EventDetailDtoValidator : AbstractValidator<EventDetailDto>
    {
        public EventDetailDtoValidator()
        {
            RuleFor(a => a.Title).NotEmpty().MaximumLength(150);
            RuleFor(a => a.Adress).MaximumLength(256);
            RuleFor(a => a.Capacity).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(a => a.EventDate).NotEmpty();
            RuleFor(a => a.ApplicationDeadline).NotEmpty();

        }
    }
}
