  using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;
using System.Collections.Generic;

namespace Trestlebridge.Actions
{
    public class ChooseComposter
    {

        public static void CollectInput(Farm farm)
        {
            Console.Clear();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Natural Field ({farm.NaturalFields[i].plantsList.Count} plant(s))");
            }

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                IEnumerable<ISeedProducing> sunflowersInPlowedField = from plant in farm.PlowedFields[i].plantsList
                                                                      where plant.Type == "Sunflower"
                                                                      select plant;

                Console.WriteLine($"{farm.NaturalFields.Count + i + 1}. Plowed Field ({sunflowersInPlowedField.Count()} plant(s))");
            }

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                IEnumerable<IGrazing> goatsInGrazingField = from animal in farm.GrazingFields[i].animalsList
                                                                      where animal.Type == "Goat"
                                                                      select animal;

                Console.WriteLine($"{farm.NaturalFields.Count + farm.PlowedFields.Count + i + 1}. Grazing Field ({goatsInGrazingField.Count()} goat(s))");
            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"Which Facility would you like to process");

            Console.Write("> ");
            Console.ReadLine();
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