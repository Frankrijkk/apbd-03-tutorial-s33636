namespace equipment_rental_service;

public class ItemRepository
{
    private List<EquipmentItem> items = new List<EquipmentItem>();
    private List<EquipmentItem> availableItems = new List<EquipmentItem>();
    public void Add(EquipmentItem item)
    {   
        items.Add(item);
        availableItems.Add(item);
    }

    public bool Rent(EquipmentItem item)
    {
        if (availableItems.Contains(item))
        {
            availableItems.Remove(item);
            return true;
        }
        return false;
    }
}