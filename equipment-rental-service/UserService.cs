using System.Globalization;
using CsvHelper;

namespace equipment_rental_service;

public class UserService
{
    private UserService _service;
    private UserService userService
    {
        get
        {
            if (_service == null)
            {
                _service=  new UserService();
                return _service;
            }
            else
            {
                return _service;
            }
        }
    }
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

    private void Save()
    {
        using (var writer = new StreamWriter("users.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                csv.WriteRecords(Persons);
                }
    }

    public void addPerson(Person person)
    {
        Persons.Add(person);
        Save();
    }
    
}