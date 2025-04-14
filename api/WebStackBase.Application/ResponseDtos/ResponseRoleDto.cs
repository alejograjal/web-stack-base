using WebStackBase.Application.ResponseDTOs.Base;

namespace WebStackBase.Application.ResponseDTOs;

public record ResponseRoleDto : BaseEntity
{
    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<ResponseUserDto> Users { get; set; } = new List<ResponseUserDto>();
}