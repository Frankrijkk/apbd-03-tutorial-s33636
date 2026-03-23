using System.Globalization;

namespace equipment_rental_service;

class CommandLineInterface
{
    static void Main(string[] args) {
        
        
        Console.WriteLine("Welcome to the PAJTK equipment rental service");
        while (true)
        {
            int choice = ChooseMenu(0,5, "What would you like to do?\n1. AddUser\n2. Add Equipment item\n3. Rent a piece of equipment\n4. Return a piece of equipment\n5. Confirm penalty payment\n0. exit");
            switch (choice)
            {
                case 1:
                    HandleAddPerson();
                    break;
                case 2:
                    HandleAddItem();
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

    private static void HandlePay()
    {
        throw new NotImplementedException();
    }

    private static void HandleRentItem()
    {
        throw new NotImplementedException();
    }

    private static void HandleReturnItem()
    {
        throw new NotImplementedException();
    }

    private static void HandleAddItem()
    {
        throw new NotImplementedException();
    }

    private static void HandleAddPerson()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Specify the name");
                string name = Console.ReadLine();
                Console.WriteLine("Specify the last name");
                string lastName = Console.ReadLine();
                int choice = ChooseMenu(1, 2, "Is it an employee or a student?\n1. Employee\n2. Student");
                bool isEmployee = false;
                switch (choice)
                {
                    case 1:
                        isEmployee = true;
                        break;
                    case 2:
                        isEmployee = false;
                        break;
                }

                Person p = new Person(name, lastName, isEmployee);
                UserService.Service.AddPerson((p));


            }
            catch (FormatException)
            {
                Console.WriteLine("Not a valid option");
            }
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