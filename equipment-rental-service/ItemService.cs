namespace equipment_rental_service;

public class ItemService
{
    ItemRepository itemRepository;
    private List<Rental> rentals;
    public bool RentItem(EquipmentItem item,Person person,int length)
    {
        if (itemRepository.Rent(item))
        {
            Rental rental = new Rental(item, person,length);
            rentals.Add(rental);
            return true;
        }
        else
        {
            return false;
        }
    }
}