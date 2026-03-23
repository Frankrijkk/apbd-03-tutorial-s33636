namespace equipment_rental_service;

public class Person : IEquatable<Person>
{
    static int _counter = 0;
    private int id;
    public string name { get; }
    public string lastName { get; }
    public PersonType? PersonType{get;set;}
    public Person(string name, string lastName, PersonType? type)
    {
        id = ++_counter;
        this.name = name;
        this.lastName = lastName;
        this.PersonType = type;
    }

    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return name == other.name && lastName==other.lastName;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Person);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, lastName);
    }
}