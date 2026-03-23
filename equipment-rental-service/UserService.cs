using System.Globalization;
using CsvHelper;

namespace equipment_rental_service;

public class UserService
{
    private UserRepository UserRepository;


    public UserService(UserRepository userRepository)
    {
        this.UserRepository =  userRepository;
    }

    public Person? Get(string firstName, string lastName)
    {
        return UserRepository.Get(firstName, lastName);
    }
    
    public bool Add(Person person)
    {
        return UserRepository.AddPerson(person);
        
    }
    
}