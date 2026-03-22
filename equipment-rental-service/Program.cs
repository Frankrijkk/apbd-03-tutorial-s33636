using System.Globalization;

namespace equipment_rental_service;

class CommandLineInterface
{
    static void Main(string[] args) {
        Console.WriteLine("Welcome to the PAJTK equipment rental service");
        int choice = chooseMenu(1, "What would you like to do?\n1. PLACEHOLDER\n0. exit");
        switch (choice)
        {
            case 1:
                Console.WriteLine("s");
                break;
            case 0:
                return;
        }
    }

    private static int chooseMenu(int max, string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string choice = Console.ReadLine();
            try
            {
                int choiceIndex = int.Parse(choice);
                if (choiceIndex >= 0 && choiceIndex <= max)
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