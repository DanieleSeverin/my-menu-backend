using Domain.Abstractions;

namespace Domain.Menus;

public static class MenuErrors
{
    public static Error NotFound = new(
    "Menu.Found",
    "The menu with the specified identifier was not found");

    public static Error Empty = new(
    "Menu.Empty",
    "The menu with the specified identifier has no dishes");
}
