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
    }
    public new string FormatProperties()
    {
        return "Lens: "+Lens+" Resolution: "+Resolution;
    }
}