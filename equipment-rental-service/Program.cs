using System.Globalization;

namespace equipment_rental_service;

class CommandLineInterface
{
    static void Main(string[] args) {
        
        
        Console.WriteLine("Welcome to the PAJTK equipment rental service");
        while (true)
        {
            int choice = ChooseMenu(0,1, "What would you like to do?\n1. PLACEHOLDER\n0. exit");
            switch (choice)
            {
                case 1:
                    HandleAddPerson();
                    break;
                case 0:
                    return;
            }
        }
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