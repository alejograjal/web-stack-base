using AutoMapper;
using WebStackBase.Domain.Core.Models;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Services.Interfaces.Authorization;

namespace WebStackBase.Application.ValueResolvers;

public class CurrentUserIdResolverAdd(IServiceUserContext serviceUserContext) : IValueResolver<RequestBaseDto, BaseEntity, string>
{
    public string Resolve(RequestBaseDto source, BaseEntity destination, string destMember, ResolutionContext context) =>
        serviceUserContext.UserId!;
}