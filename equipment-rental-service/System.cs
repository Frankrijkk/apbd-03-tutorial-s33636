namespace equipment_rental_service;

public class System
{
    public UserService UserService { get; set; }
    public ItemService ItemService { get; set; }
    public static void Main(string[] args)
    {
        System system = new System();
        CommandLineInterface cmd = new  CommandLineInterface();
        
        cmd.runMain(args,system);
    }

    public System()
    {
        ItemRepository itemRepository = new ItemRepository();
        ItemService = new ItemService(itemRepository);
        UserRepository userRepository = new  UserRepository();
        UserService = new  UserService(userRepository);
    }
}