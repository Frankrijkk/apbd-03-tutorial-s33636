namespace equipment_rental_service;

public class ItemService
{
    ItemRepository itemRepository;
    
    public bool RentItem(EquipmentItem item,Person person,int length)
    {
        if (itemRepository.Rent(item))
        {
            Rental rental = new Rental(item, person,length);
            RentalRepository.Instance.Add(rental);
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
}