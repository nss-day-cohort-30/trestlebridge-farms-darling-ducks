using System;
using System.Linq;
using Trestlebridge.Actions;
using Trestlebridge.Models;

namespace Trestlebridge
{
  class Program
  {
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

    static void Main(string[] args)
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.BackgroundColor = ConsoleColor.DarkBlue;

      Farm Trestlebridge = new Farm();

      while (true)
      {
        DisplayBanner();
        Console.WriteLine("1. Create Facility");
        Console.WriteLine("2. Purchase Animals");
        Console.WriteLine("3. Purchase Seeds");
        Console.WriteLine("4. Process Farm Products");
        Console.WriteLine("5. Display Farm Status");
        Console.WriteLine("6. Exit");
        Console.WriteLine();

        Console.WriteLine("Choose a FARMS option");
        Console.Write("> ");
        string option = Console.ReadLine();

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
