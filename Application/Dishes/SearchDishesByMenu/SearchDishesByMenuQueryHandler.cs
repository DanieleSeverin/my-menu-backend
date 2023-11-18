using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Dishes;
using Domain.Menus;

namespace Application.Dishes.SearchDishesByMenu;

internal sealed class SearchDishesByMenuQueryHandler
    : IQueryHandler<SearchDishesByMenuQuery, IReadOnlyList<DishesResponse>>
{

    private readonly IMenuRepository _menuRepository;
    private readonly IDishRepository _dishRepository;

    public SearchDishesByMenuQueryHandler(IMenuRepository menuRepository, 
                                          IDishRepository dishRepository)
    {
        _menuRepository = menuRepository;
        _dishRepository = dishRepository;
    }

    public async Task<Result<IReadOnlyList<DishesResponse>>> Handle(SearchDishesByMenuQuery request, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(new MenuId(request.MenuId));
        if (menu is null)
        {
            return Result.Failure<IReadOnlyList<DishesResponse>>(MenuErrors.NotFound);
        }

        var dishes = await _dishRepository.GetByMenuIdAsync(new MenuId(request.MenuId));

        return dishes.Select(dish => new DishesResponse(dish) ).ToList();
    }
}
