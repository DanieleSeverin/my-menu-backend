namespace Domain.Menus;

public record MenuId(Guid Value)
{
    public static MenuId New() => new(Guid.NewGuid());
}
