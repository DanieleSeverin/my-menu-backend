using Domain.Businesses;

namespace Application.Businesses.SearchBusinessBasicInfo;

public sealed class BusinessBasicInfoResponse
{
    public Guid Id { get; init; }
    public List<MenuBasicInfoResponse> Menus { get; init; }

    public BusinessBasicInfoResponse(Business businessEntity, List<MenuBasicInfoResponse> menus)
    {
        Id = businessEntity.Id.Value;
        Menus = menus;
    }
}
