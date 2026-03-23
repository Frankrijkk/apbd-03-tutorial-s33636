
namespace equipment_rental_service;

public class EquipmentItem
{
    public string Name{get;set;}
    public float DailyPenalty{get;set;}
    public int CountAvailable { get; set; }
    public EquipmentType? Type{get;set;}

    public EquipmentItem(string name)
    {
        Name = name;
        CountAvailable = 1;
        Type = null;
        

    }

    public EquipmentItem(string name, float dailyPenalty, int countAvailable)
    {
        Name = name;
        DailyPenalty = dailyPenalty;
        CountAvailable = countAvailable;
    }

    public virtual string FormatProperties()
    {
        return "";
    }
}