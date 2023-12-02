using Domain.Businesses;

namespace Application.Businesses.SearchBusinessExtendedInfo;

public sealed class BusinessExtendedInfoResponse
{
    public Guid Id { get; init; }
    public List<MenuExtendedInfoResponse> Menus { get; init; }

    public BusinessExtendedInfoResponse(Business businessEntity, List<MenuExtendedInfoResponse> menus)
    {
        Id = businessEntity.Id.Value;
        Menus = menus;
    }
}
