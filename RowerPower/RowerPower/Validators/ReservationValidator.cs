using FluentValidation;
using RowerPower.Models;

namespace RowerPower.Validators {
    public class ReservationValidator : AbstractValidator<VehicleReservationModel> {
        public ReservationValidator() {
            RuleFor(x => x.ReservationDateStart).NotEmpty().WithMessage("Pole nie może być puste.")
                .Must((reservation, reservationDateStart) => reservationDateStart < reservation.ReservationDateFinish)
                .WithMessage("Data upłynięcia terminu rezerwacji nie może być wcześniejsza od daty rozpoczęcia rezerwacji.");
        }
    }
}