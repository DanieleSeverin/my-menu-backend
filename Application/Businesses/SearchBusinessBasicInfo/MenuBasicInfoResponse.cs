using Domain.Menus;

namespace Application.Businesses.SearchBusinessBasicInfo;

public sealed class MenuBasicInfoResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }

    public MenuBasicInfoResponse(Menu menuEntity )
    {
        Id = menuEntity.Id.Value;
        Name = menuEntity.Name;
        Description = menuEntity.Description;
    }
}
