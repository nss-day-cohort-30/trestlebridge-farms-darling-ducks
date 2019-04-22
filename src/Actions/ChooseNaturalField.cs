using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ChooseNaturalField {

        //This boolean is used to check and see if the over capacity message needs to display
        public static Boolean atCapacity {get; set;}= false;
        public static void CollectInput (Farm farm, ICompostProducing plant) {
            Console.Clear();

            if (atCapacity){
                atCapacity = false;
                Console.WriteLine($@"
**** That facililty is not large enough ****
****     Please choose another one      ****");

                for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Natural Field ({farm.NaturalFields[i].plantsList.Count}/10)");
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
            Console.WriteLine ($"Place the plant where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            int correctedChoice = choice -1;

            farm.NaturalFields[correctedChoice].AddResource(plant, farm);

            }
            //runs the code if you don't need the at capacity message
            else{
                atCapacity = false;
            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Grazing Field ({farm.NaturalFields[i].plantsList.Count}/10)");
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
            Console.WriteLine ($"Place the animal where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            //corrects the users choice to match the correct index
            int correctedChoice = choice -1;

            farm.NaturalFields[correctedChoice].AddResource(plant, farm);
            }
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}