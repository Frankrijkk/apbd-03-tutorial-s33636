namespace equipment_rental_service;

public class Projector : EquipmentItem
{
    
    public string Resolution { get; }
    public string Contrast { get; }

    public Projector(string name,string res, string contrast) : base(name)
    {
        Resolution = res;
        Contrast = contrast;
        DailyPenalty = 7f;
        Type = EquipmentType.Projector;
    }
    public Projector(string name, float dailyPenalty, int count, string Resolution, string contrast) : base(name,
        dailyPenalty, count)
    {
        Contrast = contrast;
        this.Resolution = Resolution;
        DailyPenalty = 10f;
        Type = EquipmentType.Projector;
    }
    public override string FormatProperties()
    {
        return ""+Resolution+"+++"+Contrast;
    }
}