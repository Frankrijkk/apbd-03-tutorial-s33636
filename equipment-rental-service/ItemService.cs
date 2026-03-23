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

    public EquipmentItem Get(string itemName)
    {
        return _itemRepository.Get(itemName);
    }

    public string ReturnItem(Person p, string itemName)
    {
        Rental? rental = _rentalRepository.GetActive(p, itemName);
        if (rental is null) return "Couldn't find a rental for this item name";
        EquipmentItem item = Get(rental.EquipmentItem.Name);
        if (item is null) return "something went wrong";
        item.CountAvailable++;
        _itemRepository.Save();
        rental.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
        _rentalRepository.Save();
        
        
        if (rental.ReturnDate > rental.DueDate)
        {
            float debt = rental.EquipmentItem.DailyPenalty* (rental.ReturnDate.Value.DayNumber-rental.DueDate.DayNumber);
            p.Debt = debt;
            return "Extended the due date - Penalty issued: " + debt;
        }

        return "Return item success. No penalty issued";

    }

    public void SaveAll()
    {
        _itemRepository.Save();
        _rentalRepository.Save();
    }

    public string ListItems()
    {
        List<EquipmentItem> l = _itemRepository.GetAll();
        string finalString = "";
        foreach (var item in l)
        {
            string[] properties = item.FormatProperties().Split("+++");
            finalString += item.Type + ": " + item.Name;
            foreach (string property in properties)finalString += " - " + property;
            finalString+=". Available: " + item.CountAvailable +
                           ". Penalty per day for Extending the rent: " + item.DailyPenalty+"\n";
        }
        return finalString;
    }
}