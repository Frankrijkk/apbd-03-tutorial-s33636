using System.ComponentModel;
using System.Globalization;

namespace equipment_rental_service;

class CommandLineInterface
{
    
    public void runMain(string[] args,System system) {
        
        
        Console.WriteLine("Welcome to the PAJTK equipment rental service");
        while (true)
        {
            int choice = ChooseMenu(0,5, "What would you like to do?\n1. AddUser\n2. Add Equipment item\n3. Rent a piece of equipment\n4. Return a piece of equipment\n5. Confirm penalty payment\n0. exit");
            switch (choice)
            {
                case 1:
                    HandleAddPerson(system.UserService);
                    break;
                case 2:
                    HandleAddItem(system.ItemService);
                    break;
                case 3:
                    HandleRentItem();
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

    private void HandleRentItem()
    {
        throw new NotImplementedException();
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
        string name = Console.ReadLine();
        EquipmentItem item = new EquipmentItem(type, name);

        itemService.Add(item);
    }

    private void HandleAddPerson(UserService service)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Specify the name");
                string name = Console.ReadLine();
                Console.WriteLine("Specify the last name");
                string lastName = Console.ReadLine();
                PersonType? personType = ChooseMenuEnum<PersonType>( "What kind of person is it?");
                if (personType is null) return;
                

                Person p = new Person(name, lastName, personType);
                if(service.AddPerson((p))) return;
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
            string choice = Console.ReadLine();
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