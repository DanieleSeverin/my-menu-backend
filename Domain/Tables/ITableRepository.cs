namespace Domain.Tables;

public interface ITableRepository
{
    public Task<Table?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public void Add(Table table);
}
