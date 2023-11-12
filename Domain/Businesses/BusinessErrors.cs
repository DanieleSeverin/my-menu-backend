using Domain.Abstractions;

namespace Domain.Businesses;

public static class BusinessErrors
{
    public static Error NotFound = new(
    "Business.Found",
    "The business with the specified identifier was not found");

    public static Error TableNotFound = new(
    "Business.Table.Found",
    "The table with the specified identifier was not found");

    public static Error NoMenus = new(
    "Business.NoMenu",
    "The business with the specified identifier has no menu");
}
