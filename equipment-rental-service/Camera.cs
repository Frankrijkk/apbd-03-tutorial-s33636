namespace equipment_rental_service;

public class Camera :EquipmentItem
{
    public string Lens { get; }
    public string Resolution { get; }

    public Camera(string name,string lens, string res) : base(name)
    {
        this.Lens = lens;
        this.Resolution = res;
        DailyPenalty = 5f;
        Type = EquipmentType.Camera;
    }
    public Camera(string name, float dailyPenalty, int count, string Lens, string Resolution) : base(name,
        dailyPenalty, count)
    {
        this.Lens = Lens;
        this.Resolution = Resolution;
        DailyPenalty = 10f;
        Type = EquipmentType.Camera;
    }
    public override string FormatProperties()
    {
        return Lens+"+++"+Resolution;
    }
}