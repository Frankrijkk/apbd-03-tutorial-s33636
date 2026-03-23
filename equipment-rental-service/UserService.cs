

namespace equipment_rental_service;

public class UserService
{
    private readonly UserRepository _userRepository;


    public UserService(UserRepository userRepository)
    {
        this._userRepository =  userRepository;
    }

    public Person? Get(string? firstName, string? lastName)
    {
        if (firstName is not null && lastName is not null) return _userRepository.Get(firstName, lastName);
        else return null;
    }
    
    public bool Add(Person person)
    {
        return _userRepository.AddPerson(person);
        
    }

    public void UpdateUsers()
    {
        _userRepository.Save();
    }

    public bool ClearDebt(Person person)
    {
        person.Debt = 0;
        UpdateUsers();
        return true;

    }
}