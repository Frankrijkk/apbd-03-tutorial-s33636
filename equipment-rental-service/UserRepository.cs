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
            var records = File.ReadAllLines("users.csv");
            foreach (var personstring in records)
            {
                string[] personArray = personstring.Split(",");
                PersonType? type = null;
                switch (personArray[3])
                {
                    case "Student":
                        type = PersonType.Student;
                        break;
                    case "Employee":
                        type = PersonType.Employee;
                        break;
                        
                }
                Person person = new Person(int.Parse(personArray[0]), personArray[1], personArray[2],type,float.Parse(personArray[4]));
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