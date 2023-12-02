using Application.Abstractions.Messaging;

namespace Application.Businesses.SearchBusiness;

public sealed record SearchBusinessQuery(Guid BusinessId) : IQuery<SearchBusinessResponse>;
