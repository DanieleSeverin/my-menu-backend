using Domain.Abstractions;

namespace Domain.Tables;

public static class TableErrors
{
    public static Error NotFound = new(
        "Table.Found",
        "The table with the specified identifier was not found");
}
