using Application.Businesses.SearchBusinessExtendedInfo;
using Domain.Businesses;

namespace Application.Businesses.SearchBusiness;

public sealed class SearchBusinessResponse
{
    public Guid Id { get; init; }

    public SearchBusinessResponse(Business businessEntity)
    {
        Id = businessEntity.Id.Value;
    }
}
