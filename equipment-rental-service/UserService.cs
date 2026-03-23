using System.Globalization;
using CsvHelper;

namespace equipment_rental_service;

public class UserService
{

    private List<Person> _persons;
    public static UserService Service = new UserService();
    public UserService()
    {
        _persons = new List<Person>();
        using (var reader = new StreamReader("users.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Person>();
            foreach (var person in records)
            {
                _persons.Add(person);
            }
        }
    }

    private void Save()
    {
        using (var writer = new StreamWriter("users.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                csv.WriteRecords(_persons);
                }
    }

    public void AddPerson(Person person)
    {
        _persons.Add(person);
        Save();
    }
    
}