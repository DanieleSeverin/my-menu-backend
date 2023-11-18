using Domain.Tables;

namespace Infrastructure.Repositories;

internal sealed class TableRepository : ITableRepository
{
    public void Add(Table table)
    {
        throw new NotImplementedException();
    }

    public Task<Table?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
