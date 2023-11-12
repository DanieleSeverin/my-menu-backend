using Domain.Menus;
using Domain.Tables;

namespace Domain.Businesses;

public class Business
{
    public Guid Id { get; init; }
    public List<Table> Tables { get; init; }
    public List<Menu> Menus { get; init; }

    public Business()
    {
        Id = Guid.NewGuid();
        Tables = new List<Table>();
        Menus = new List<Menu>();
    }

    public Table? GetTableById(Guid tableId)
    {
        return Tables.FirstOrDefault(t => t.Id == tableId);
    }

    public void AddTable(Table table)
    {
        Tables.Add(table);
    }

    public void RemoveTable(Guid tableId)
    {
        var table = Tables.FirstOrDefault(x => x.Id == tableId);
        if (table is not null)
        {
            Tables.Remove(table);
        }
    }

    public void AddMenu(Menu menu)
    {
        Menus.Add(menu);
    }

    public void RemoveMenu(Guid menuId)
    {
        var menu = Menus.FirstOrDefault(x => x.Id == menuId);
        if (menu is not null)
        {
            Menus.Remove(menu);
        }
    }
}
