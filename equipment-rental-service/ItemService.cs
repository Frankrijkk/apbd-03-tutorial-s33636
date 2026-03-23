namespace equipment_rental_service;

public class ItemService
{
    private readonly ItemRepository _itemRepository;
    private readonly RentalRepository _rentalRepository;
    public ItemService(ItemRepository itemRepository,RentalRepository rentalRepository)
    {
        this._itemRepository = itemRepository;
        this._rentalRepository = rentalRepository;
    }
    public string RentItem(EquipmentItem item,Person person,int length)
    {
        //person not in debt do the uni, person has max 5/2 rentals,
        if (person.Debt>0) return "Pay your Debt: "+person.Debt;
        if (!_rentalRepository.Check(person)) return "Return something first";
        if (_itemRepository.Rent(item))
        {
            Rental rental = new Rental(item, person,length);
            _rentalRepository.Add(rental);
            return "success";
        }
        else
        {
            return "something went wrong";
        }
    }

    public bool Add(EquipmentItem item)
    {
        return _itemRepository.Add(item);
        
    }

    public EquipmentItem? GetAvailable(string? itemName)
    {
        if (itemName is not null) return _itemRepository.GetAvailable(itemName);
        else return null;
    }
}