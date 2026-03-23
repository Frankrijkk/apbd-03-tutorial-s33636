namespace equipment_rental_service;

public class Person : IEquatable<Person>
{
    private static int _counter = 0;
    private int id;
    public string Name { get; }
    public string LastName { get; }
    public PersonType? PersonType{get;set;}
    public float Debt{get;set;}
    public Person(string name, string lastName, PersonType? type)
    {
        id = ++_counter;
        this.Name = name;
        this.LastName = lastName;
        this.PersonType = type;
        Debt = 0;
    }

    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name && LastName==other.LastName;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Person);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, LastName);
    }

    public int GetMaxRentals()
    {
        switch (this.PersonType)
        {
            case equipment_rental_service.PersonType.Employee:
                return 5;
                break;
            case equipment_rental_service.PersonType.Student:
                return 2;
                break;
            default:
                return 0;
                break;
            
        }
    }
}