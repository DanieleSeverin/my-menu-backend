using Domain.Businesses;
using Domain.Tables;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class TableRepository : ITableRepository
{
    private readonly ApplicationDbContext DbContext;

    public TableRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add(Table table)
    {
        DbContext.Add<Table>(table);
    }

    public async Task<Table?> GetByIdAsync(TableId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Table>()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }
}
