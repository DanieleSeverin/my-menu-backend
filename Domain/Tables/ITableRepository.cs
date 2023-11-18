namespace Domain.Tables;

public interface ITableRepository
{
    public Task<Table?> GetByIdAsync(TableId id, CancellationToken cancellationToken = default);

    public void Add(Table table);
}
