using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Reports;

namespace Trestlebridge.Actions
{
  public class MeatProcessorInGrazingField
  {
    public static void ListResources(Farm farm, string id, string type)
    {
      IEnumerable<GrazingField> CorrectFieldEnumerable = from field in farm.GrazingFields
                                                         where field.ShortId == id
                                                         select field;

      List<GrazingField> CorrectFieldList = CorrectFieldEnumerable.ToList();

      GrazingField CorrectField = CorrectFieldList[0];

      IEnumerable<GrazingFieldReport> OrderedAnimals = (from animal in CorrectField.animalsList
                                                        group animal by animal.Type into NewGroup
                                                        select new GrazingFieldReport
                                                        {
                                                          AnimalType = NewGroup.Key,
                                                          Number = NewGroup.Count().ToString()
                                                        }
          );


      List<GrazingFieldReport> AnimalList = OrderedAnimals.ToList();

      int count = 1;

      Console.WriteLine();
      Console.WriteLine("The following is in the Grazing Field:");
      Console.WriteLine();
      foreach (GrazingFieldReport animal in AnimalList)
      {
        Console.WriteLine($"{count}: {animal.Number} {animal.AnimalType}");
        count++;
      }

      Console.WriteLine();
      Console.WriteLine("Which resource should be processed?");
      Console.Write("> ");
      int choice = Int32.Parse(Console.ReadLine());
      int correctedChoice = choice - 1;

      string AnimalType = AnimalList[correctedChoice].AnimalType;

      Console.WriteLine($"How many {AnimalType} should be processed? (Max 7)");
      int amountToProcess = Int32.Parse(Console.ReadLine());

      if (amountToProcess > 7)
      {
        Console.WriteLine("Learn to read, dumbass");
        amountToProcess = Int32.Parse(Console.ReadLine());
      }
      if (amountToProcess <= 7)
      {
        farm.ProcessingList.Add(new ToProcess
        {
          FacilityId = CorrectField.ShortId,
          Type = AnimalType,
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
            ChooseMeatProcessor.CollectInput(farm);
            break;
          default:
            break;
        }
      }
    }
  }
}