using Application.Abstractions.Messaging;

namespace Application.Businesses.SearchBusinessBasicInfo;

public sealed record BusinessBasicInfoQuery(Guid BusinessId) : IQuery<BusinessBasicInfoResponse>;
