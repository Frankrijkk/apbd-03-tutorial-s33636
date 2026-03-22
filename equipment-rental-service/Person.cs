namespace equipment_rental_service;

public class Person
{
    private string name { get; }
    private string lastName { get; }
    private bool isEmployee{get;set;}
    public Person(string name, string lastName, bool isEmployee)
    {
        this.name = name;
        this.lastName = lastName;
        this.isEmployee = isEmployee;
    }
}