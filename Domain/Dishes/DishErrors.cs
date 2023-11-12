using Domain.Abstractions;

namespace Domain.Dishes;

public static class DishErrors
{
    public static Error NotFound = new(
    "Dish.Found",
    "The dish with the specified identifier was not found");
}
