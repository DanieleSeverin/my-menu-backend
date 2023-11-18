namespace Domain.Tables;

public record TableId(Guid Value)
{
    public static TableId New() => new(Guid.NewGuid());
}
