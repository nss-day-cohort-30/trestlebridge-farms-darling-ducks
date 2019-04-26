using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Reports;

namespace Trestlebridge.Actions
{
    public class EggHarvesterInChickenHouse
    {
        public static void ListResources(Farm farm, string id, string type)
        {
            IEnumerable<ChickenHouse> CorrectChickenHouseEnumerable = from house in farm.ChickenHouses
                                                               where house.ShortId == id
                                                               select house;

            List<ChickenHouse> CorrectHouseList = CorrectChickenHouseEnumerable.ToList();

            ChickenHouse CorrectHouse= CorrectHouseList[0];

            IEnumerable<ChickenHouseReport> OrderedChicken = (from chicken in CorrectHouse.animalsList
                                                              group chicken by chicken.Type into NewGroup
                                                              select new ChickenHouseReport
                                                              {
                                                                  AnimalType = NewGroup.Key,
                                                                  Number = NewGroup.Count().ToString()
                                                              }
                );

            // IEnumerable<NaturalFieldReport> JustSunflowers = from flower in OrderedFlowers
            //                                                  where flower.PlantType == "Sunflower"
            //                                                  select flower;

            List<ChickenHouseReport> OrderedChickenList = OrderedChicken.ToList();

            int count = 1;

            Console.WriteLine();
            Console.WriteLine("The following Chickens are in the house");
            Console.WriteLine();
            foreach (ChickenHouseReport chicken in OrderedChickenList)
            {
                Console.WriteLine($"{count}: {chicken.Number} {chicken.AnimalType}");
                count++;
            }

            Console.WriteLine();
            Console.WriteLine("Which resource should be processed?");
            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            int correctedChoice = choice - 1;

            string AnimalType = OrderedChickenList[correctedChoice].AnimalType;

            Console.WriteLine($"How many {AnimalType} should be processed? (Max 7)");
            int amountToProcess = Int32.Parse(Console.ReadLine());

            if (amountToProcess > 7)
            {
                Console.WriteLine("Learn to read, dumbass");
                amountToProcess = Int32.Parse(Console.ReadLine());
            }
            if (amountToProcess <= 5)
            {
                farm.ProcessingList.Add(new ToProcess
                {
                    FacilityId = CorrectHouse.ShortId,
                    Type = AnimalType,
                    AmountToProcess = amountToProcess
                });

                Console.WriteLine("Ready to process? (Y/n)");
                Console.Write("> ");
                string input = Console.ReadLine();
                

                switch (input)
                {
                    case "Y":
                        break;
                    case "n":
                        ChooseEggGatherer.CollectInput(farm);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}