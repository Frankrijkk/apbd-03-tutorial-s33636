

namespace equipment_rental_service;

public class Rental
{
    public DateOnly RentalDate { get; set; } 
    public DateOnly DueDate {get; set;}
    public DateOnly? ReturnDate {get; set;}
    public EquipmentItem EquipmentItem {get; set;}
    public Person Person {get; set;}

    public Rental(EquipmentItem item,Person person, int length)
    {
        RentalDate = DateOnly.FromDateTime(DateTime.Now);
        DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(length));
        ReturnDate = null;
        EquipmentItem = item;
        Person=person;
    }
}