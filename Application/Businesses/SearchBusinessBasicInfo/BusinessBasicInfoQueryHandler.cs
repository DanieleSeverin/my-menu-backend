using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Businesses;
using Domain.Menus;

namespace Application.Businesses.SearchBusinessBasicInfo;

internal sealed class BusinessBasicInfoQueryHandler
    : IQueryHandler<BusinessBasicInfoQuery, BusinessBasicInfoResponse>
{

    private readonly IBusinessRepository _businessRepository;
    private readonly IMenuRepository _menuRepository;

    public BusinessBasicInfoQueryHandler(IBusinessRepository businessRepository,
                                         IMenuRepository menuRepository)
    {
        _businessRepository = businessRepository;
        _menuRepository = menuRepository;
    }

    public async Task<Result<BusinessBasicInfoResponse>> Handle(BusinessBasicInfoQuery request, CancellationToken cancellationToken)
    {
        var business = await _businessRepository.GetByIdAsync(new BusinessId(request.BusinessId));

        if (business is null)
        {
            return Result.Failure<BusinessBasicInfoResponse>(BusinessErrors.NotFound);
        }

        var menus = await _menuRepository.GetByBusinessIdAsync(new BusinessId(request.BusinessId));

        if (!menus.Any())
        {
            return Result.Failure<BusinessBasicInfoResponse>(BusinessErrors.NoMenus);
        }

        var menusInfo = menus
            .Select(menu => new MenuBasicInfoResponse(menu))
            .ToList();

        return new BusinessBasicInfoResponse(business, menusInfo);
    }
}
