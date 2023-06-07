using AutoMapper;
using RowerPower.Models;
using RowerPower.Repo;

namespace RowerPower.Profiles {
    public class AutomapperProfile : Profile {
        public AutomapperProfile() {
            CreateMap<VehicleDetailViewModel, VehicleModel>()
                .ForMember(
                    dest => dest.VehicleId,
                    opt => opt.MapFrom(
                        src => src.Id
                    )
                );

            CreateMap<VehicleModel, VehicleDetailViewModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(
                        src => src.VehicleId
                    )
                );

            CreateMap<VehicleModel, VehicleItemViewModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(
                        src => src.VehicleId
                    )
                );

            CreateMap<VehicleRentalSpotModel, VehicleRentalSpotViewModel>().ReverseMap();
            CreateMap<VehicleReservationModel, VehicleReservationViewModel>().ReverseMap();
            CreateMap<UserModel, UserRepository>().ReverseMap();
            CreateMap<UserModel, UserViewModel>().ReverseMap(); //??

        }
    }
}