
using System.Globalization;
using System.Text.Json.Serialization;
using CsvHelper;

namespace equipment_rental_service;

public class ItemRepository
{
    private List<EquipmentItem> _items;
    public bool Add(EquipmentItem item)
    {
        bool found = false;
        foreach (var availableItem in _items)
        {
            if (availableItem.Name.Equals(item.Name))
            {
                availableItem.CountAvailable++;
                found = true;
            }
        
        }
        if (!found) _items.Add(item);
        Save();
        return true;
    }

    public ItemRepository()
    {
        _items = new List<EquipmentItem>();
        if (!File.Exists("items.csv"))
        {
            File.Create("items.csv").Close();
        }

        {
            
            var records = File.ReadAllLines("items.csv");
            foreach (string itemstring in records)
            {
                
                string[] itemArray = itemstring.Split(";");
                string name = itemArray[0];
                float dailyPenalty = float.Parse(itemArray[1]);
                int count = int.Parse(itemArray[2]);
                string[] props = itemArray[4].Split("+++");

                switch (itemArray[3])
                {
                    case "Laptop":
                        EquipmentItem laptop = new Laptop(name, dailyPenalty, count, props[0],props[1]);
                        _items.Add(laptop);
                        break;
                    case "Projector":
                        EquipmentItem projector = new Projector(name, dailyPenalty, count, props[0], props[1]);
                        _items.Add(projector);
                        break;
                    case "Camera":
                        EquipmentItem camera = new Camera(name, dailyPenalty, count, props[0], props[1]);
                        _items.Add(camera);
                        break;
                    
                }
            }
        }
    }
    public void Save()
    {
        //name;Penalty;Count;type;p1+++p2
        using var writer = new StreamWriter("items.csv");
        foreach (var availableItem in _items)
        {
            string fmt = availableItem.Name + ";" + availableItem.DailyPenalty + ";" + availableItem.CountAvailable +
                         ";" + availableItem.Type + ";" + availableItem.FormatProperties();
            writer.WriteLine(fmt);
        }
    }

    public bool Rent(EquipmentItem item)
    {
        foreach (var availableItem in _items)
        {
            if (availableItem.Name.Equals(item.Name))
            {
                if (availableItem.CountAvailable > 0)
                {
                    availableItem.CountAvailable--;
                    Save();
                    return true;
                }
            }
        
        }
        return false;
    }

    public EquipmentItem? GetAvailable(string itemName)
    {
        foreach (var item in _items)
        {
            if (item.Name == itemName)
            {
                if (item.CountAvailable > 0) return item;
            }
        }

        return null;
    }

    public EquipmentItem Get(string itemName)
    {
        foreach (var item in _items)
        {
            if (item.Name == itemName)
            {
                return item;
            }
        }

        return null; //should never happen
    }
}