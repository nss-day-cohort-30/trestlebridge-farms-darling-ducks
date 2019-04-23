using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
  public class HowManyPlants
  {
    public static void AskHowManyPlants(Farm farm, string type)
    {
      Console.WriteLine("How many are you planting?");

      Console.Write("> ");
      string numberofPlants = Console.ReadLine();
      int intofPlants = Int32.Parse(numberofPlants);

      if (type == "sesame")
      {
          ChoosePlowedField.CollectInput(farm, intofPlants, type);
      }
      if (type == "sunflower")
      {
          ChoosePlowedOrNaturalField.CollectInput(farm, intofPlants, type);
      }
      if (type == "wildflower")
      {
          ChooseNaturalField.CollectInput(farm, intofPlants, type);
      }
    }
  }
}