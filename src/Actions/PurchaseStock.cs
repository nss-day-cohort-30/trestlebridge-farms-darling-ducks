using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
  public class PurchaseStock
  {
    // Displays Purchase Stock sub-menu options to user

    public static void CollectInput(Farm farm)
    {
      Console.WriteLine("1. Cow");
      Console.WriteLine("2. Ostrich");
      Console.WriteLine("3. Chicken");
      Console.WriteLine("4. Duck");
      Console.WriteLine("5. Goat");
      Console.WriteLine("6. Pig");
      Console.WriteLine("7. Sheep");

      Console.WriteLine();
      Console.WriteLine("What are you buying today?");

      Console.Write("> ");

      // stores user's input in variable "choice"
      string choice = Console.ReadLine();

      // try and catch statements prevent the program from closing if the user's chooses an invalid option
      try
      {

        // The user's input is parsed to an integer, and a switch statement proceses the user's choice, adding a new animal to the farm.

        switch (Int32.Parse(choice))
        {
          case 1:
            ChooseGrazingField.CollectInput(farm, new Cow());
            break;
          case 2:
            ChooseGrazingField.CollectInput(farm, new Ostrich());
            break;
          case 3:
            ChooseChickenHouse.CollectInput(farm, new Chicken());
            break;
          case 4:
            ChooseDuckHouse.CollectInput(farm, new Duck());
            break;
          case 5:
            ChooseGrazingField.CollectInput(farm, new Goat());
            break;
          case 6:
            ChooseGrazingField.CollectInput(farm, new Pig());
            break;
          case 7:
            ChooseGrazingField.CollectInput(farm, new Sheep());
            break;

          // integers other than 1-7 result in the default message
          default:
            Console.WriteLine();
            Console.WriteLine("Invalid input! Press any key to return home");
            Console.ReadLine();
            break;
        }
      }

      // Catches an error if the user enters input that can't be parsed to an integer, informs the user, and returns the user to the main menu
      catch (FormatException)
      {
        Console.WriteLine();
        Console.WriteLine("Invalid input! Press any key to return home");
        Console.ReadLine();
      }
    }
  }
}