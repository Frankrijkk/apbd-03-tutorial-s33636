namespace equipment_rental_service;

public class System
{
    
    public static void Main(string[] args)
    {
        System systen = new System();
        CommandLineInterface cmd = new  CommandLineInterface();
        cmd.runMain(args);
    }

    public System()
    {
        
    }
}