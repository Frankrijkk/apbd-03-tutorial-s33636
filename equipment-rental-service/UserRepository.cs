using System.Globalization;
using CsvHelper;

namespace equipment_rental_service;

public class UserRepository
{
    private List<Person> _persons;
    
    public UserRepository()
    {
        _persons = new List<Person>();
        if (!File.Exists("users.csv"))
        {
            File.Create("users.csv").Close();
        }

        {
            using var reader = new StreamReader("users.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Person>();
            foreach (var person in records)
            {
                _persons.Add(person);
            }
        }
    }

    private void Save()
    {
        using var writer = new StreamWriter("users.csv");
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(_persons);
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

    public Person? Get(string firstname, string lastname)
    {
        Person person = new Person(firstname, lastname,null);
        foreach (Person p in _persons)
        {
            if (person.Equals(p))
            {
                return p;
            }
        }
        return null;
    }

}