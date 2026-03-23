using System.Transactions;

namespace equipment_rental_service;

public class Laptop: EquipmentItem
{
    public string GraphicsCard { get; }
    public string Processor { get; }

    public Laptop(string name,string graphicsCard, string processor) : base(name)
    {
        GraphicsCard = graphicsCard;
        Processor = processor;
        DailyPenalty = 10f;
    }
    public new string FormatProperties()
    {
        return "GPU: "+GraphicsCard+" CPU: "+Processor;
    }
}