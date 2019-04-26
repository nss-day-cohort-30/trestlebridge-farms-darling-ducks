using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;
using System.Collections.Generic;

namespace Trestlebridge.Actions
{
    public class ChooseSeedHarvester
    {

        public static void CollectInput(Farm farm)
        {
            Console.Clear();

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Plowed Field ({farm.PlowedFields[i].plantsList.Count}) plants");
            }

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                IEnumerable<ICompostProducing> sunflowersInNaturalField = from plant in farm.NaturalFields[i].plantsList
                                                                          where plant.Type == "Sunflower"
                                                                          select plant;

                Console.WriteLine($"{farm.PlowedFields.Count + i + 1}. Natural Field ({sunflowersInNaturalField.Count()}) plants");
            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"Which Facility would you like to process");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            int correctedChoice = choice - 1;

            if (farm.PlowedFields.Count == 0 && farm.NaturalFields.Count > 0)
            {
                string shortId = farm.NaturalFields[correctedChoice].ShortId;
                SeedHarvesterInNaturalField.ListResources(farm, shortId, "Natural Field");
            }
            else if (farm.NaturalFields.Count == 0 && farm.PlowedFields.Count > 0)
            {
                string shortId = farm.PlowedFields[correctedChoice].ShortId;
                // SeedHarvesterInPlowedField.ListResources(farm, shortId, "Plowed Field");
            }
            else if (correctedChoice >= farm.PlowedFields.Count)
            {
                string shortId = farm.NaturalFields[correctedChoice - farm.PlowedFields.Count].ShortId;
                SeedHarvesterInNaturalField.ListResources(farm, shortId, "Natural Field");
            }
            else if (correctedChoice < farm.PlowedFields.Count)
            {
                string shortId = farm.PlowedFields[correctedChoice].ShortId;
                // SeedHarvesterInPlowedField.ListResources(farm, shortId, "Plowed Field");
            }

            // farm.NaturalFields[correctedChoice].AddResource(farm, number, plantType);

            //runs the code if you don't need the at capacity message

        }
    }
}