using AutoMapper;
using WebStackBase.Application.ResponseDtos;
using WebStackBase.Application.ResponseDTOs;

namespace WebStackBase.Infrastructure.Mappings.Mappers;

public class ModelToDtoApplicationProfile : Profile
{
    public ModelToDtoApplicationProfile()
    {
        CreateMap<CustomerFeedback, ResponseCustomerFeedbackDto>();

        CreateMap<Reservation, ResponseReservationDto>();

        CreateMap<ReservationDetail, ResponseReservationDetailDto>()
            .ForMember(dest => dest.Reservation, inp => inp.MapFrom(ori => ori.Reservation))
            .ForMember(dest => dest.Service, inp => inp.MapFrom(ori => ori.Service));

        CreateMap<Resource, ResponseResourceDto>()
            .ForMember(dest => dest.ResourceType, inp => inp.MapFrom(ori => ori.ResourceType));

        CreateMap<ResourceType, ResponseResourceTypeDto>();

        CreateMap<Role, ResponseRoleDto>();

        CreateMap<Service, ResponseServiceDto>();

        CreateMap<ServiceResource, ResponseServiceResourceDto>()
            .ForMember(dest => dest.Service, inp => inp.MapFrom(ori => ori.Service))
            .ForMember(dest => dest.Resource, inp => inp.MapFrom(ori => ori.Resource));

        CreateMap<User, ResponseUserDto>()
            .ForMember(dest => dest.Role, inp => inp.MapFrom(ori => ori.Role));
    }
}