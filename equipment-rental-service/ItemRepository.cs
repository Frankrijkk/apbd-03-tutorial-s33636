
namespace equipment_rental_service;

public class ItemRepository
{
    private List<EquipmentItem> _items = new List<EquipmentItem>();
    private readonly List<EquipmentItem> _availableItems = new List<EquipmentItem>();
    public bool Add(EquipmentItem item)
    {   
        _items.Add(item);
        _availableItems.Add(item);
        Save();
        return true;
    }

    private void Save()
    {
        return; //TODO
    }

    public bool Rent(EquipmentItem item)
    {
        if (_availableItems.Contains(item))
        {
            _availableItems.Remove(item);
            return true;
        }
        return false;
    }

    public EquipmentItem? GetAvailable(string itemName)
    {
        foreach (var item in _availableItems)
        {
            if (item.Name == itemName) return item;
        }

        return null;
    }
}