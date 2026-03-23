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
    }
    public new string FormatProperties()
    {
        return "Resolution: "+Resolution+" Contrast: "+Contrast;
    }
}