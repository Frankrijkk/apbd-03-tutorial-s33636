using System.ComponentModel.Design;
using System.Globalization;
using CsvHelper;

namespace equipment_rental_service;

public class RentalRepository
{
    private List<Rental> _rentals;
    private void Save()
    {
        using (var writer = new StreamWriter("rentals.csv"))
        {
            foreach (Rental rental in _rentals)
            {
                EquipmentItem availableItem = rental.EquipmentItem;
                string returndate = rental.ReturnDate is null ? "null" : rental.ReturnDate.Value.ToString("dd/MM/yyyy");
                string fmt = rental.RentalDate.ToString("dd/MM/yyyy")+";"+ rental.DueDate.ToString("dd/MM/yyyy")+ ";"+returndate+";"+availableItem.Name + ";" + availableItem.DailyPenalty + ";" + availableItem.CountAvailable +
                             ";" + availableItem.Type + ";" + availableItem.FormatProperties()+";"+rental.Person.Name+";"+rental.Person.LastName;
                writer.Write(fmt);
            }
            
                
            
        }
    }

    public void Add(Rental rental)
    {
        _rentals.Add(rental);
        Save();
        
        
    }
    public RentalRepository()
    {
        _rentals = new List<Rental>();
        if (!File.Exists("rentals.csv"))
        {
            File.Create("rentals.csv").Close();
        }

        

        var records = File.ReadAllLines(@"rentals.csv");
            foreach (var rental in records)
            {
                string[] values = rental.Split(';');
                DateOnly rentalDate = DateOnly.ParseExact(values[0], "dd/MM/yyyy");
                DateOnly duedate = DateOnly.ParseExact(values[1], "dd/MM/yyyy");
                DateOnly? returnDate;
                if (values[2] == "null") returnDate = null;
                else returnDate = DateOnly.ParseExact(values[2], "dd/MM/yyyy");
                string itemName =  values[3];
                float dailyPenalty = float.Parse(values[4]);
                int count = int.Parse(values[5]);
                string[] props =  values[7].Split("+++");
                EquipmentItem? item = null;
                switch (values[6])
                {
                    case "Laptop":
                        item = new Laptop(itemName, dailyPenalty, count, props[0],props[1]);
                        break;
                    case "Projector":
                         item = new Projector(itemName, dailyPenalty, count, props[0], props[1]);
                        break;
                    case "Camera":
                         item = new Camera(itemName, dailyPenalty, count, props[0], props[1]);
                        break;
                }

                Person p = new Person(values[8], values[9], null);
                Rental r = new Rental(rentalDate, duedate, returnDate, item, p);
                _rentals.Add(r);
            }
        
    }

    public bool Check(Person p)
    {
        int maxcount = p.GetMaxRentals();
        int count = 0;
        foreach (Rental rental in _rentals)
        {
            if (rental.Person.Equals(p))
            {
                
                count++;
            }
        }

        if (count < maxcount) return true;
        return false;

    }
    
    
}