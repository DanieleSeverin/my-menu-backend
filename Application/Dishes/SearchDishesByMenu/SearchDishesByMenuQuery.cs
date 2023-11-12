using Application.Abstractions.Messaging;

namespace Application.Dishes.SearchDishesByMenu;

public sealed record SearchDishesByMenuQuery(Guid MenuId) : IQuery<IReadOnlyList<DishesResponse>>;
