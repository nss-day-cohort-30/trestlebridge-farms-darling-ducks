using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseDuckHouse
    {

        //This boolean is used to check and see if the over capacity message needs to display
        public static Boolean atCapacity { get; set; } = false;
        public static void CollectInput(Farm farm, Duck animal)
        {
            Console.Clear();

            if (atCapacity)
            {
                atCapacity = false;
                Console.WriteLine($@"
**** That facility is not large enough ****
****     Please choose another one      ****");

                for (int i = 0; i < farm.DuckHouses.Count; i++)
                {
                    if (farm.DuckHouses[i].animalsList.Count < farm.DuckHouses[i].Capacity)
                    {
                        Console.WriteLine($"{i + 1}. Duck House ({farm.DuckHouses[i].animalsList.Count} ducks/{farm.DuckHouses[i].Capacity})");
                    }
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                Console.WriteLine($"Place the animal where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());
                int correctedChoice = choice - 1;

                farm.DuckHouses[correctedChoice].AddResource(animal, farm);

            }
            //runs the code if you don't need the at capacity message
            else
            {
                atCapacity = false;
                for (int i = 0; i < farm.DuckHouses.Count; i++)
                {
                    if (farm.DuckHouses[i].animalsList.Count < farm.DuckHouses[i].Capacity)
                    {
                        Console.WriteLine($"{i + 1}. Duck House ({farm.DuckHouses[i].animalsList.Count} ducks/{farm.DuckHouses[i].Capacity})");
                    }
                    Console.WriteLine("\n");
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                Console.WriteLine($"Place the animal where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());
                //corrects the users choice to match the correct index
                int correctedChoice = choice - 1;

                farm.DuckHouses[correctedChoice].AddResource(animal, farm);
            }
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}