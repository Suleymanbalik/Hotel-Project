using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidatior : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidatior()
        {
            RuleFor(m => m.GuestFirstName).NotEmpty().WithMessage("This Field Can Not Be Passed Empty!");
            RuleFor(m => m.GuestLastName).NotEmpty().WithMessage("This Fiedl Can Not Be Passed Empty!");
            RuleFor(m => m.GuestCity).NotEmpty().WithMessage("This Field Can Not Be Passed Empty!");
            RuleFor(m => m.GuestFirstName).MinimumLength(2).WithMessage("Minimum length must be at least 2 characters!");
            RuleFor(m => m.GuestLastName).MinimumLength(2).WithMessage("Minimum length must be at least 2 characters!");
            RuleFor(m => m.GuestCity).MinimumLength(3).WithMessage("Minimum length must be at least 3 characters!");
        }
    }
}
