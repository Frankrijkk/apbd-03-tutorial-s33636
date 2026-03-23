namespace equipment_rental_service;

public class RentalSystem
{
    public UserService UserService { get; set; }
    public ItemService ItemService { get; set; }
    public static void Main(string[] args)
    {
        RentalSystem rentalSystem = new RentalSystem();
        CommandLineInterface cmd = new  CommandLineInterface();
        
        cmd.RunMain(args,rentalSystem);
    }

    private RentalSystem()
    {
        ItemRepository itemRepository = new ItemRepository();
        RentalRepository rentalRepository = new RentalRepository();
        ItemService = new ItemService(itemRepository,rentalRepository);
        UserRepository userRepository = new  UserRepository();
        UserService = new  UserService(userRepository);
    }

    public void SaveAll()
    {
        ItemService.SaveAll();
        UserService.UpdateUsers();
    }
}