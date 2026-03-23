
using System.Runtime.CompilerServices;

namespace equipment_rental_service;

class CommandLineInterface
{
    
    public void RunMain(string[] args,RentalSystem rentalSystem) {
        
        
        Console.WriteLine("Welcome to the PJATK equipment rental service");
        while (true)
        {
            int choice = ChooseMenu(0,5, "What would you like to do?\n1. AddUser\n2. Add Equipment item\n3. Rent a piece of equipment\n4. Return a piece of equipment\n5. Confirm penalty payment\n0. exit");
            switch (choice)
            {
                case 1:
                    HandleAddPerson(rentalSystem.UserService);
                    break;
                case 2:
                    HandleAddItem(rentalSystem.ItemService);
                    break;
                case 3:
                    HandleRentItem(rentalSystem);
                    break;
                case 4:
                    HandleReturnItem();
                    break;
                case 5:
                    HandlePay();
                    break;
                case 0:
                    return;
            }
        }
    }

    private void HandlePay()
    {
        throw new NotImplementedException();
    }

    private void HandleRentItem(RentalSystem rentalSystem)
    {
        try
        {
            Console.WriteLine("What is the first name of the renter?");
            string? name = Console.ReadLine();
            Console.WriteLine("What is the last name of the item?");
            string? lastName = Console.ReadLine();
            Person? p = rentalSystem.UserService.Get(name, lastName);
            if (p is null)
            {
                Console.WriteLine("Person was not found in the system");
                return;
            }

            Console.WriteLine("What is the name of the item?");
            string? itemName = Console.ReadLine();
            EquipmentItem? item = rentalSystem.ItemService.GetAvailable(itemName);
            if (item is null)
            {
                Console.WriteLine("Item is currently not available");
                return;
            }

            Console.WriteLine("How many days would the rental be?(max 31)");
            int days;
            try
            {
                string? daysString = Console.ReadLine();
                if (daysString is null) return;
                days = int.Parse(daysString);
                if (days > 31)
                {
                    Console.WriteLine("Not a valid number");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a valid number");
                return;
            }


            Console.WriteLine(rentalSystem.ItemService.RentItem(item, p, days));
            return;

        }
        catch (IOException)
        {
            Console.WriteLine("something went wrong please try again");
        }
    }

    private void HandleReturnItem()
    {
        throw new NotImplementedException();
    }

    private void HandleAddItem(ItemService itemService)
    {
        
        EquipmentType? type = ChooseMenuEnum<EquipmentType>("What type of item would you like to add?\\n");
        if (type is null) return;

        Console.WriteLine("Enter Item name");
        string? name = Console.ReadLine();
        if (name is null) return;
        EquipmentItem item=null;
        switch (type)
        {
            case EquipmentType.Laptop:
                Console.WriteLine("Enter the laptops graphics card");
                string? gpu =  Console.ReadLine();
                Console.WriteLine("Enter the laptops processor");
                string? cpu =  Console.ReadLine();
                if (gpu is null||cpu is null)return;
                item = new Laptop(name,gpu,cpu);
                break;
            case EquipmentType.Camera:
                Console.WriteLine("Enter the Camera's lens type");
                string? lens =  Console.ReadLine();
                Console.WriteLine("Enter the Camera's photo resolution");
                string? res =  Console.ReadLine();
                if (lens is null||res is null)return;
                item = new Camera(name,lens,res);
                break;
            case EquipmentType.Projector:
                Console.WriteLine("Enter the Projector's resoultion");
                string? reso =  Console.ReadLine();
                Console.WriteLine("Enter the Projector's contrast");
                string? contr =  Console.ReadLine();
                if (reso is null||contr is null)return;
                item = new Projector(name,reso,contr);
                break;
            default:
                break;
        }
        if(item is not null)
            if (itemService.Add(item))
            {
                Console.WriteLine("Success");
                return;
            }

        Console.WriteLine("Item was not added");
    }

    private void HandleAddPerson(UserService service)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Specify the name");
                string? name = Console.ReadLine();
                Console.WriteLine("Specify the last name");
                string? lastName = Console.ReadLine();
                PersonType? personType = ChooseMenuEnum<PersonType>( "What kind of person is it?");
                if (personType is null||name is null||lastName is null) return;
                

                Person p = new Person(name, lastName, personType);
                if(service.Add((p))) return;
                Console.WriteLine("Person was not added");

            }
            catch (FormatException)
            {
                Console.WriteLine("Not a valid option");
            }
        }
    }

    private static T? ChooseMenuEnum<T>(string prompt) where T : struct, Enum
    {


        while (true)
        {
            Console.WriteLine(prompt);
            T[] options = (T[])Enum.GetValues(typeof(T));

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= options.Length)
            {
                if (choice == 0) return null;
                return options[choice - 1];
            }

            Console.WriteLine("Invalid selection. Please try again.");
        }
    }

    private static int ChooseMenu(int min,int max, string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string? choice = Console.ReadLine();
            if (choice is null) continue;
            try
            {
                int choiceIndex = int.Parse(choice);
                if (choiceIndex >= min && choiceIndex <= max)
                {
                    return choiceIndex;
                }
                else
                {
                    Console.WriteLine("Not a valid option");

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a valid option");
            }
        }
    }
}