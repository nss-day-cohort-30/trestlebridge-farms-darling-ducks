using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class PurchaseSeed
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Sesame");
            Console.WriteLine("2. Sunflower");
            Console.WriteLine("3. Wildflower");

            Console.WriteLine();
            Console.WriteLine("What are you buying today?");

            Console.Write("> ");
            string choice = Console.ReadLine();

            try
            {
                switch (Int32.Parse(choice))
                {
                    case 1:
                        HowManyPlants.AskHowManyPlants(farm, "sesame");
                        break;
                    case 2:
                        HowManyPlants.AskHowManyPlants(farm, "sunflower");
                        break;
                    case 3:
                        HowManyPlants.AskHowManyPlants(farm, "wildflower");
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input! Press any key to return home");
                Console.ReadLine();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input! Press any key to return home");
                Console.ReadLine();
            }
        }
    }
}