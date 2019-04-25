using System;
using System.Linq;
using Trestlebridge.Actions;
using Trestlebridge.Models;

namespace Trestlebridge
{
  class Program
  {

    // Method to display banner for FARMS program
    static void DisplayBanner()
    {
      Console.Clear();
      Console.WriteLine();
      Console.WriteLine(@"
        +-++-++-++-++-++-++-++-++-++-++-++-++-+
        |T||r||e||s||t||l||e||b||r||i||d||g||e|
        +-++-++-++-++-++-++-++-++-++-++-++-++-+
                    |F||a||r||m||s|
                    +-++-++-++-++-+");
      Console.WriteLine();
    }

    // Main method to launch program. Also sets foreground color to white and background to dark blue, harkening a simpler more Commodore 64-esque era.
    static void Main(string[] args)
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.BackgroundColor = ConsoleColor.DarkBlue;

      // Creates Trestlebridge object
      Farm Trestlebridge = new Farm();

      // While loop keeps user in FARMS program
      while (true)
      {
        // Displays banner and main menu options to user
        DisplayBanner();
        Console.WriteLine("1. Create Facility");
        Console.WriteLine("2. Purchase Animals");
        Console.WriteLine("3. Purchase Seeds");
        Console.WriteLine("4. Process Farm Products");
        Console.WriteLine("5. Display Farm Status");
        Console.WriteLine("6. Exit");
        Console.WriteLine();

        // Prompts user to select the number of the desired option
        Console.WriteLine("Choose a FARMS option");
        Console.Write("> ");
        string option = Console.ReadLine();

        // Reads user's input and presents the associated sub-menu for the chosen option
        if (option == "1")
        {
          DisplayBanner();
          CreateFacility.CollectInput(Trestlebridge);
        }
        else if (option == "2")
        {
          DisplayBanner();
          PurchaseStock.CollectInput(Trestlebridge);
        }
        else if (option == "3")
        {
          DisplayBanner();
          PurchaseSeed.CollectInput(Trestlebridge);
        }
        else if (option == "4")
        {
          DisplayBanner();
          ChooseProcessingOption.CollectInput(Trestlebridge);
        }

        else if (option == "5")
        {
          DisplayBanner();
          Console.WriteLine(Trestlebridge);
          Console.WriteLine("\n\n\n");
          Console.WriteLine("Press return key to go back to main menu.");
          Console.ReadLine();
        }

        // Exits program and prints a warm departure message to the user
        else if (option == "6")
        {
          Console.WriteLine("Rest well. Tomorrow brings another day of plowing fields and ethically raising happy animals for farm-to-table restaurants all over Nashville.");
          break;
        }
        else
        {
          Console.WriteLine($"Invalid option: {option}");
        }
      }
    }
  }
}
