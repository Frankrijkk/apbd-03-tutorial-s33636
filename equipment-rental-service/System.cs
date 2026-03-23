namespace equipment_rental_service;

public class System
{
    public UserService UserService { get; set; }
    public ItemService ItemService { get; set; }
    public static void Main(string[] args)
    {
        System system = new System();
        CommandLineInterface cmd = new  CommandLineInterface();
        
        cmd.RunMain(args,system);
    }

    private System()
    {
        ItemRepository itemRepository = new ItemRepository();
        RentalRepository rentalRepository = new RentalRepository();
        ItemService = new ItemService(itemRepository,rentalRepository);
        UserRepository userRepository = new  UserRepository();
        UserService = new  UserService(userRepository);
    }
}