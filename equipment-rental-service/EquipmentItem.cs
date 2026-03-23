
namespace equipment_rental_service;

public class EquipmentItem
{
    public string Name{get;set;}
    public float DailyPenalty{get;set;}

    public EquipmentItem(string name)
    {
        Name = name;
        
        
    }

    public string FormatProperties()
    {
        return "";
    }
}