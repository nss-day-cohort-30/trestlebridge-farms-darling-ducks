using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Reports;

namespace Trestlebridge.Actions
{
    public class ChoosePlowedOrNaturalField
    {

        //This boolean is used to check and see if the over capacity message needs to display
        public static Boolean atCapacity { get; set; } = false;
        public static void CollectInput(Farm farm, int number, string plantType)
        {
            Console.Clear();

            if (atCapacity)
            {
                atCapacity = false;
                Console.WriteLine($@"
**** That facililty is not large enough ****
****     Please choose another one      ****");

                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    Console.Write($"{i + 1}. Plowed Field ");
                    IEnumerable<PlowedFieldReport> MultipleFieldFlowers = (from flower in farm.PlowedFields[i].plantsList
                                                                           group flower by flower.Type into NewGroup
                                                                           select new PlowedFieldReport
                                                                           {
                                                                               PlantType = NewGroup.Key,
                                                                               Number = NewGroup.Count().ToString()
                                                                           }
                    );
                    foreach (PlowedFieldReport flower in MultipleFieldFlowers)
                    {
                        Console.Write($@" ({flower.Number} {flower.PlantType})");
                    }

                    if (farm.PlowedFields[i].plantsList.Count < farm.PlowedFields[i].Capacity)
                    {
                        // Console.WriteLine($"{i + 1}. Plowed Field ({farm.PlowedFields[i].plantsList.Count}/{farm.PlowedFields[i].Capacity})");
                    }
                    Console.WriteLine("\n");
                }

                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    Console.Write($"{farm.PlowedFields.Count + i + 1}. Natural Field ");
                    IEnumerable<NaturalFieldReport> ManyFieldFlowers = (from flower in farm.NaturalFields[i].plantsList
                                                                        group flower by flower.Type into NewGroup
                                                                        select new NaturalFieldReport
                                                                        {
                                                                            PlantType = NewGroup.Key,
                                                                            Number = NewGroup.Count().ToString()
                                                                        }
                    );
                    foreach (NaturalFieldReport flower in ManyFieldFlowers)
                    {
                        Console.Write($@" ({flower.Number} {flower.PlantType})");
                    }
                    if (farm.NaturalFields[i].plantsList.Count < farm.NaturalFields[i].Capacity)
                    {
                        // Console.WriteLine($"{farm.PlowedFields.Count + i + 1}. Natural Field ({farm.NaturalFields[i].plantsList.Count}/{farm.NaturalFields[i].Capacity})");
                    }
                    Console.WriteLine("\n");
                }

                Console.WriteLine();

                // How can I output the type of plant chosen here?
                Console.WriteLine($"Place the plant where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());
                int correctedChoice = choice - 1;

                if (farm.PlowedFields.Count == 0 && farm.NaturalFields.Count > 0)
                {
                    farm.NaturalFields[correctedChoice].AddResource(farm, number, plantType);
                }
                else if (farm.NaturalFields.Count == 0 && farm.PlowedFields.Count > 0)
                {
                    farm.PlowedFields[correctedChoice].AddResource(farm, number, plantType);
                }
                else if (correctedChoice >= farm.PlowedFields.Count)
                {
                    farm.NaturalFields[correctedChoice - farm.PlowedFields.Count].AddResource(farm, number, plantType);
                }
                else if (correctedChoice < farm.PlowedFields.Count)
                {
                    farm.PlowedFields[correctedChoice].AddResource(farm, number, plantType);
                }

            }
            //runs the code if you don't need the at capacity message
            else
            {
                atCapacity = false;
                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    Console.Write($"{i + 1}. Plowed Field ");
                    IEnumerable<PlowedFieldReport> MultipleFieldFlowers = (from flower in farm.PlowedFields[i].plantsList
                                                                           group flower by flower.Type into NewGroup
                                                                           select new PlowedFieldReport
                                                                           {
                                                                               PlantType = NewGroup.Key,
                                                                               Number = NewGroup.Count().ToString()
                                                                           }
                    );
                    foreach (PlowedFieldReport flower in MultipleFieldFlowers)
                    {
                        Console.Write($@" ({flower.Number} {flower.PlantType})");
                    }

                    if (farm.PlowedFields[i].plantsList.Count < farm.PlowedFields[i].Capacity)
                    {
                        // Console.WriteLine($"{i + 1}. Plowed Field ({farm.PlowedFields[i].plantsList.Count}/{farm.PlowedFields[i].Capacity})");
                    }
                    Console.WriteLine("\n");
                }

                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    Console.Write($"{farm.PlowedFields.Count + i + 1}. Natural Field ");
                    IEnumerable<NaturalFieldReport> ManyFieldFlowers = (from flower in farm.NaturalFields[i].plantsList
                                                                        group flower by flower.Type into NewGroup
                                                                        select new NaturalFieldReport
                                                                        {
                                                                            PlantType = NewGroup.Key,
                                                                            Number = NewGroup.Count().ToString()
                                                                        }
                    );
                    foreach (NaturalFieldReport flower in ManyFieldFlowers)
                    {
                        Console.Write($@" ({flower.Number} {flower.PlantType})");
                    }
                    if (farm.NaturalFields[i].plantsList.Count < farm.NaturalFields[i].Capacity)
                    {
                        // Console.WriteLine($"{farm.PlowedFields.Count + i + 1}. Natural Field ({farm.NaturalFields[i].plantsList.Count}/{farm.NaturalFields[i].Capacity})");
                    }
                    Console.WriteLine("\n");
                }

                Console.WriteLine();

                // How can I output the type of plant chosen here?
                Console.WriteLine($"Place the plant where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());
                //corrects the users choice to match the correct index
                int correctedChoice = choice - 1;

                if (farm.PlowedFields.Count == 0 && farm.NaturalFields.Count > 0)
                {
                    farm.NaturalFields[correctedChoice].AddResource(farm, number, plantType);
                }
                else if (farm.NaturalFields.Count == 0 && farm.PlowedFields.Count > 0)
                {
                    farm.PlowedFields[correctedChoice].AddResource(farm, number, plantType);
                }
                else if (correctedChoice >= farm.PlowedFields.Count)
                {
                    farm.NaturalFields[correctedChoice - farm.PlowedFields.Count].AddResource(farm, number, plantType);
                }
                else if (correctedChoice < farm.PlowedFields.Count)
                {
                    farm.PlowedFields[correctedChoice].AddResource(farm, number, plantType);
                }
            }
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<ISeedProducing>(plant, choice);

        }
    }
}