namespace equipment_rental_service;

public class Person : IEquatable<Person>
{
    public string name { get; }
    public string lastName { get; }
    public bool isEmployee{get;set;}
    public Person(string name, string lastName, bool isEmployee)
    {
        this.name = name;
        this.lastName = lastName;
        this.isEmployee = isEmployee;
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