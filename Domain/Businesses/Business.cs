using Domain.Menus;
using Domain.Tables;

namespace Domain.Businesses;

public class Business
{
    public BusinessId Id { get; init; }
    public List<Table> Tables { get; init; }
    public List<Menu> Menus { get; init; }

    public Business()
    {
        Id = BusinessId.New();
        Tables = new List<Table>();
        Menus = new List<Menu>();
    }

    public Table? GetTableById(TableId tableId)
    {
        return Tables.FirstOrDefault(t => t.Id.Value == tableId.Value);
    }

    public void AddTable(Table table)
    {
        Tables.Add(table);
    }

    public void RemoveTable(TableId tableId)
    {
        var table = Tables.FirstOrDefault(x => x.Id.Value == tableId.Value);
        if (table is not null)
        {
            Tables.Remove(table);
        }
    }

    public void AddMenu(Menu menu)
    {
        Menus.Add(menu);
    }

    public void RemoveMenu(MenuId menuId)
    {
        var menu = Menus.FirstOrDefault(x => x.Id.Value == menuId.Value);
        if (menu is not null)
        {
            Menus.Remove(menu);
        }
    }
}
