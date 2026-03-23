using System.Globalization;
using CsvHelper;

namespace equipment_rental_service;

public class RentalRepository
{
    private List<Rental> _rentals = new List<Rental>();
    public static RentalRepository Instance { get; } = new RentalRepository();
    private void Save()
    {
        using (var writer = new StreamWriter("rentals.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(_rentals);
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
        using (var reader = new StreamReader("users.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Rental>();
            foreach (var rental in records)
            {
                _rentals.Add(rental);
            }
        }
    }
    
    
}