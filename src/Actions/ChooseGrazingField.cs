using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseGrazingField {

        public static Boolean atCapacity {get; set;}= false;
        public static void CollectInput (Farm farm, IGrazing animal) {
            Console.Clear();

            if (atCapacity){
                atCapacity = false;
                Console.WriteLine($@"
**** That facililty is not large enough ****
****     Please choose another one      ****");

                for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Grazing Field");
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
            Console.WriteLine ($"Place the animal where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            int correctedChoice = choice -1;

            farm.GrazingFields[correctedChoice].AddResource(animal, farm);

            }
            else{
                atCapacity = false; 
            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Grazing Field");
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
            Console.WriteLine ($"Place the animal where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            int correctedChoice = choice -1;

            farm.GrazingFields[correctedChoice].AddResource(animal, farm);
            }
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}