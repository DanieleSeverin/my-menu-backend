namespace Domain.Businesses;

public record BusinessId(Guid Value)
{
    public static BusinessId New() => new(Guid.NewGuid());
}
