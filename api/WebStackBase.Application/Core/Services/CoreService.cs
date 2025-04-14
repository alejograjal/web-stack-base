using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStackBase.Application.Core.Interfaces;

namespace WebStackBase.Application.Core.Services;

public class CoreService<T>(ILogger<T> logger, IMapper autoMapper, IUnitOfWork unitOfWork) : ICoreService<T>
{
    public ILogger<T> Logger { get { return logger; } }
    public IMapper AutoMapper { get { return autoMapper; } }
    public IUnitOfWork UnitOfWork { get { return unitOfWork; } }
}