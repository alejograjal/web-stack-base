using AutoMapper;
using WebStackBase.Domain.Core.Models;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.ValueResolvers;

namespace WebStackBase.Infrastructure.Mappings.Mappers;

public class DtoToModelApplicationProfile : Profile
{
    public DtoToModelApplicationProfile()
    {
        CreateMap<RequestBaseDto, BaseEntity>()
            .ForMember(m => m.CreatedBy, opts =>
            {
                opts.MapFrom<CurrentUserIdResolverAdd>();
            })
            .ForMember(m => m.UpdatedBy, opts =>
            {
                opts.MapFrom<CurrentUserIdResolverModify>();
            });

        CreateMap<RequestCustomerFeedbackDto, CustomerFeedback>();

        CreateMap<RequestReservationDto, Reservation>();

        CreateMap<RequestReservationDetailDto, ReservationDetail>();

        CreateMap<RequestResourceDto, Resource>()
            .IncludeBase<RequestBaseDto, BaseEntity>();

        CreateMap<RequestServiceDto, Service>()
            .IncludeBase<RequestBaseDto, BaseEntity>();

        CreateMap<RequestServiceResourceDto, ServiceResource>();
    }
}