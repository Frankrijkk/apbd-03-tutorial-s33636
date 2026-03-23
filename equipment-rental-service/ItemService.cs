namespace equipment_rental_service;

public class ItemService
{
    ItemRepository itemRepository;
    RentalRepository RentalRepository;
    public ItemService(ItemRepository itemRepository)
    {
        this.itemRepository = itemRepository;
    }
    public bool RentItem(EquipmentItem item,Person person,int length)
    {
        if (itemRepository.Rent(item))
        {
            Rental rental = new Rental(item, person,length);
            RentalRepository.Add(rental);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Add(EquipmentItem item)
    {
        return itemRepository.Add(item);
        
    }

    public EquipmentItem GetAvailable(string itemName)
    {
        itemRepository.
    }
}