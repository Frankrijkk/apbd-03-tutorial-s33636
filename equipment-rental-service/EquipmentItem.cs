using System.ComponentModel;

namespace equipment_rental_service;

public class EquipmentItem
{
    public string Type { get; set; }
    public string Name{get;set;}
    public float DailyPenalty{get;set;}

    public EquipmentItem(EquipmentType? type,string name)
    {
        Type = type.ToString();
        Name = name;
        switch (type)
        {
            case EquipmentType.Laptop :
                DailyPenalty = 10f;
                break;
            case EquipmentType.Camera :
                DailyPenalty = 5f;
                break;
            case EquipmentType.Projector:
                DailyPenalty = 7f;
                break;
        }
        
    }
}