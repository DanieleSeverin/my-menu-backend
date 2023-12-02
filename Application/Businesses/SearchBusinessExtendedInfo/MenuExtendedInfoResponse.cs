using Domain.Menus;

namespace Application.Businesses.SearchBusinessExtendedInfo;

public sealed class MenuExtendedInfoResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }

    public MenuExtendedInfoResponse(Menu menuEntity)
    {
        Id = menuEntity.Id.Value;
        Name = menuEntity.Name;
        Description = menuEntity.Description;
    }
}
