using Application.Abstractions.Messaging;

namespace Application.Businesses.SearchBusinessExtendedInfo;

public sealed record BusinessExtendedInfoQuery(Guid BusinessId) : IQuery<BusinessExtendedInfoResponse>;
