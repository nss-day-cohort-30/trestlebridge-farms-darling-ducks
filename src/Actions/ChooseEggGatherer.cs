using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseEggGatherer
    {

        public static void CollectInput(Farm farm)
        {
            Console.Clear();

            for (int i = 0; i < farm.DuckHouses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Duck House ({farm.DuckHouses[i].animalsList.Count})");
            }

            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                Console.WriteLine($"{farm.DuckHouses.Count + i + 1}. Chicken House ({farm.ChickenHouses[i].animalsList.Count})");

            }
            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                IEnumerable<IGrazing> ostrichInGrazingField = from animal in farm.GrazingFields[i].animalsList
                                                              where animal.Type == "Ostrich"
                                                              select animal;

                Console.WriteLine($"{farm.DuckHouses.Count + farm.ChickenHouses.Count + i + 1}. Grazing Field ({ostrichInGrazingField.Count()})");
            }

            Console.WriteLine();

            Console.WriteLine($"Which Facility would you like to process?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            int correctedChoice = choice - 1;

            if (farm.DuckHouses.Count == 0 && farm.ChickenHouses.Count > 0)
            {
                string shortId = farm.ChickenHouses[correctedChoice].ShortId;
                EggHarvesterInChickenHouse.ListResources(farm, shortId, "Duck House");
            }
            else if (farm.ChickenHouses.Count == 0 && farm.DuckHouses.Count > 0)
            {
                string shortId = farm.DuckHouses[correctedChoice].ShortId;
                // SeedHarvesterInPlowedField.ListResources(farm, shortId, "Plowed Field");
            }
            else if (correctedChoice >= farm.DuckHouses.Count)
            {
                string shortId = farm.ChickenHouses[correctedChoice - farm.DuckHouses.Count].ShortId;
                EggHarvesterInChickenHouse.ListResources(farm, shortId, "Chicken House");
            }
            else if (correctedChoice < farm.DuckHouses.Count)
            {
                string shortId = farm.DuckHouses[correctedChoice].ShortId;
                // SeedHarvesterInPlowedField.ListResources(farm, shortId, "Plowed Field");
            }
        }
    }
}