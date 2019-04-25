using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChooseProcessingOption
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Seed Harvester");
            Console.WriteLine("2. Meat Processor");
            Console.WriteLine("3. Egg Gatherer");
            Console.WriteLine("4. Composter");
            Console.WriteLine("5. Feather Harvester");

            Console.WriteLine();
            Console.WriteLine("Choose equipment to use.");

            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (Int32.Parse(choice))
                {
                    
                    case 2:
                        ChooseMeatProcessor.CollectInput(farm);
                        break;
                    case 4:
                        ChooseComposter.CollectInput(farm);
                        break;
                    default:
                        break;
                }


        }
    }
}