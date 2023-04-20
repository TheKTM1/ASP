using FluentValidation;
using RowerPower.Models;

namespace RowerPower.Validators {
    public class VehicleValidator : AbstractValidator<VehicleModel> {
        public VehicleValidator() {
            RuleFor(x => x.VehicleId).NotEmpty().WithMessage("Pole nie może być puste.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pole nie może być puste.");
            RuleFor(x => x.Producer).NotEmpty().WithMessage("Pole nie może być puste.");
        }
    }
}
