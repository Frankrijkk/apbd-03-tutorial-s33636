using System.Data;

namespace equipment_rental_service;

public class Rental
{
    public DateOnly RentalDate { get; set; } 
    private DateOnly DueDate {get; set;}
    private Nullable<DateOnly> ReturnDate {get; set;}
    private EquipmentItem EquipmentItem {get; set;}
    private Person Person {get; set;}

    public Rental(EquipmentItem item,Person person, int length)
    {
        RentalDate = DateOnly.FromDateTime(DateTime.Now);
        DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(length));
        ReturnDate = null;
        EquipmentItem = item;
        Person=person;
    }
}