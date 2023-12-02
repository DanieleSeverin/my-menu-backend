using Application.Abstractions.Messaging;
using Application.Businesses.SearchBusinessExtendedInfo;
using Domain.Abstractions;
using Domain.Businesses;
using Domain.Menus;

namespace Application.Businesses.SearchBusiness;

internal sealed class SearchBusinessQueryHandler
    : IQueryHandler<SearchBusinessQuery, SearchBusinessResponse>
{

    private readonly IBusinessRepository _businessRepository;
    private readonly IMenuRepository _menuRepository;

    public SearchBusinessQueryHandler(IBusinessRepository businessRepository,
                                         IMenuRepository menuRepository)
    {
        _businessRepository = businessRepository;
        _menuRepository = menuRepository;
    }

    public async Task<Result<SearchBusinessResponse>> Handle(SearchBusinessQuery request, CancellationToken cancellationToken)
    {
        var business = await _businessRepository.GetByIdAsync(new BusinessId(request.BusinessId));

        if (business is null)
        {
            return Result.Failure<SearchBusinessResponse>(BusinessErrors.NotFound);
        }

        return new SearchBusinessResponse(business);
    }
}
