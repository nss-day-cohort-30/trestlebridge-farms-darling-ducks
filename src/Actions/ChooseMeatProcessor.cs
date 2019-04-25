using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ChooseMeatProcessor {

        public static void CollectInput (Farm farm) {
            Console.Clear();

            for (int i = 0; i < farm.GrazingFields.Count; i++)
                {
                        Console.WriteLine($"{i + 1}. Grazing Field ({farm.PlowedFields[i].plantsList.Count})");
                }

                for (int i = 0; i < farm.ChickenHouses.Count; i++)
                {
                        Console.WriteLine($"{farm.GrazingFields.Count + i + 1}. Chiken House ({farm.ChickenHouses[i].animalsList.Count})");

                }

                Console.WriteLine();

                // How can I output the type of plant chosen here?
                Console.WriteLine($"Which Facility would you like to process");

                Console.Write("> ");
            //     int choice = Int32.Parse(Console.ReadLine());
            //     int correctedChoice = choice - 1;

            //     if (farm.PlowedFields.Count == 0 && farm.NaturalFields.Count > 0)
            //     {
            //         farm.NaturalFields[correctedChoice].AddResource(farm, number, plantType);
            //     }
            //     else if (farm.NaturalFields.Count == 0 && farm.PlowedFields.Count > 0)
            //     {
            //         farm.PlowedFields[correctedChoice].AddResource(farm, number, plantType);
            //     }
            //     else if (correctedChoice >= farm.PlowedFields.Count)
            //     {
            //         farm.NaturalFields[correctedChoice - farm.PlowedFields.Count].AddResource(farm, number, plantType);
            //     }
            //     else if (correctedChoice < farm.PlowedFields.Count)
            //     {
            //         farm.PlowedFields[correctedChoice].AddResource(farm, number, plantType);
            //     }

            // farm.NaturalFields[correctedChoice].AddResource(farm, number, plantType);

            //runs the code if you don't need the at capacity message

        }
    }
}