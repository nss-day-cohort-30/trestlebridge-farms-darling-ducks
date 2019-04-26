using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Reports;

namespace Trestlebridge.Actions
{
    public class SeedHarvesterInNaturalField
    {
        public static void ListResources(Farm farm, string id, string type)
        {
            IEnumerable<NaturalField> CorrectFieldEnumerable = from field in farm.NaturalFields
                                                               where field.ShortId == id
                                                               select field;

            List<NaturalField> CorrectFieldList = CorrectFieldEnumerable.ToList();

            NaturalField CorrectField = CorrectFieldList[0];

            IEnumerable<NaturalFieldReport> OrderedFlowers = (from flower in CorrectField.plantsList
                                                              group flower by flower.Type into NewGroup
                                                              select new NaturalFieldReport
                                                              {
                                                                  PlantType = NewGroup.Key,
                                                                  Number = NewGroup.Count().ToString()
                                                              }
                );

            IEnumerable<NaturalFieldReport> JustSunflowers = from flower in OrderedFlowers
                                                             where flower.PlantType == "Sunflower"
                                                             select flower;

            List<NaturalFieldReport> OrderedSunflowersList = JustSunflowers.ToList();

            int count = 1;

            Console.WriteLine();
            Console.WriteLine("The following flowers are in the Natural Field");
            Console.WriteLine();
            foreach (NaturalFieldReport flower in JustSunflowers)
            {
                Console.WriteLine($"{count}: {flower.Number} {flower.PlantType}");
                count++;
            }

            Console.WriteLine();
            Console.WriteLine("Which resource should be processed?");
            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            int correctedChoice = choice - 1;

            string PlantType = OrderedSunflowersList[correctedChoice].PlantType;

            Console.WriteLine($"How many {PlantType} should be processed? (Max 5)");
            int amountToProcess = Int32.Parse(Console.ReadLine());

            if (amountToProcess > 5)
            {
                Console.WriteLine("Learn to read, dumbass");
                amountToProcess = Int32.Parse(Console.ReadLine());
            }
            if (amountToProcess <= 5)
            {
                farm.ProcessingList.Add(new ToProcess
                {
                    FacilityId = CorrectField.ShortId,
                    Type = PlantType,
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
                        ChooseSeedHarvester.CollectInput(farm);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}