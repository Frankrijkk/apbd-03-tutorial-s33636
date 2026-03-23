using System.Globalization;
using CsvHelper;

namespace equipment_rental_service;
//TODO add a userRepository
public class UserService
{

    private List<Person> _persons;
    public static UserService Service = new UserService();
    public UserService()
    {
        _persons = new List<Person>();
        if (!File.Exists("users.csv"))
        {
            File.Create("users.csv").Close();
        }
        {
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
    }

    private void Save()
    {
        using (var writer = new StreamWriter("users.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                csv.WriteRecords(_persons);
                }
    }

    public bool AddPerson(Person person)
    {
        if (!_persons.Contains(person))
        {
            _persons.Add(person);
            Save();
            return true;
        }
        return false;
    }
    
}