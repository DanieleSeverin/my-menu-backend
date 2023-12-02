using Application.Abstractions.Messaging;
using Application.Businesses.SearchBusiness;
using Domain.Abstractions;
using Domain.Businesses;
using Domain.Menus;

namespace Application.Businesses.SearchBusinessExtendedInfo;

internal sealed class BusinessExtendedInfoQueryHandler
    : IQueryHandler<BusinessExtendedInfoQuery, BusinessExtendedInfoResponse>
{

    private readonly IBusinessRepository _businessRepository;
    private readonly IMenuRepository _menuRepository;

    public BusinessExtendedInfoQueryHandler(IBusinessRepository businessRepository,
                                         IMenuRepository menuRepository)
    {
        _businessRepository = businessRepository;
        _menuRepository = menuRepository;
    }

    public async Task<Result<BusinessExtendedInfoResponse>> Handle(BusinessExtendedInfoQuery request, CancellationToken cancellationToken)
    {
        var business = await _businessRepository.GetByIdAsync(new BusinessId(request.BusinessId));

        if (business is null)
        {
            return Result.Failure<BusinessExtendedInfoResponse>(BusinessErrors.NotFound);
        }

        var menus = await _menuRepository.GetByBusinessIdAsync(new BusinessId(request.BusinessId));

        if (!menus.Any())
        {
            return Result.Failure<BusinessExtendedInfoResponse>(BusinessErrors.NoMenus);
        }

        var menusInfo = menus
            .Select(menu => new MenuExtendedInfoResponse(menu))
            .ToList();

        return new BusinessExtendedInfoResponse(business, menusInfo);
    }
}
