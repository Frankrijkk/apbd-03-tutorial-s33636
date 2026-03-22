using System.Globalization;
using CsvHelper;

namespace equipment_rental_service;

public class UserService
{
    private List<Person> Persons { get; set; }

    public UserService()
    {
        Persons = new List<Person>();
        using (var reader = new StreamReader("users.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Person>();
            foreach (var person in records)
            {
                Persons.Add(person);
            }
        }
    }

    public void Save()
    {
        using (var writer = new StreamWriter("users.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                csv.WriteRecords(Persons);
                }
    }
}