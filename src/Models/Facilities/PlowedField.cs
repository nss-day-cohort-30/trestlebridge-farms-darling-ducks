using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Plants;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class PlowedField : IFacility<ISeedProducing>
    {
        private int _capacity = 13;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _plants = new List<ISeedProducing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }
        public List<ISeedProducing> plantsList {
            get {
                return _plants;
            }
        }

        public void AddResource (Farm farm, int number, string plantType)
        {
            if (_plants.Count + number <= _capacity) {
                if (plantType == "sesame")
                {
                    for (int i = 0; i < number; i++)
                    {
                        _plants.Add(new Sesame());
                    }
                }
                if (plantType == "sunflower")
                {
                    for (int i = 0; i < number; i++)
                    {
                        _plants.Add(new Sunflower());
                    }
                }
            }
            else {
                ChoosePlowedField.atCapacity = true;
                ChoosePlowedField.CollectInput(farm, number, plantType);
            }
        }

         public void AddResource (ISeedProducing plant)
        {
            if (_plants.Count < _capacity) {
                _plants.Add(plant);
            }
        }

        public void AddResource (List<ISeedProducing> plants)  // TODO: Take out this method for boilerplate
        {
            if (_plants.Count + plants.Count <= _capacity) {
                _plants.AddRange(plants);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed field {shortId} has {this._plants.Count} row(s) of plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}