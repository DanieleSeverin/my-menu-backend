namespace Domain.Dishes;

public record DishId(Guid Value)
{
    public static DishId New() => new(Guid.NewGuid());
}


