﻿using Domain.Dishes;
using Domain.Menus;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class DishRepository : IDishRepository
{
    private readonly ApplicationDbContext DbContext;

    public DishRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Dish?> GetByIdAsync(DishId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Dish>().FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }

    public async Task<List<Dish>> GetByMenuIdAsync(MenuId menuId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Dish>().Where(d => d.MenuId == menuId).ToListAsync(cancellationToken);
    }
}
