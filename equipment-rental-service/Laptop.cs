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
        Type = EquipmentType.Laptop;
    }

    public Laptop(string name, float dailyPenalty, int count, string graphicsCard, string processor) : base(name,
        dailyPenalty, count)
    {
        GraphicsCard = graphicsCard;
        Processor = processor;
        DailyPenalty = 10f;
        Type = EquipmentType.Laptop;
    }
    public override string FormatProperties()
    {
        return GraphicsCard+"+++"+Processor;
    }

    public override string ToString()
    {
        return Type+": "+ Name+" - " + GraphicsCard+ " - " +  Processor;
    }
}