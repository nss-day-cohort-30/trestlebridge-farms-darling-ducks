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

        public void AddResource (ISeedProducing plant, Farm farm)
        {
            if (_plants.Count < _capacity) {
                _plants.Add(plant);
            }
            else {
                ChoosePlowedField.atCapacity = true;
                ChoosePlowedField.CollectInput(farm, plant);
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

            output.Append($"Plowed field {shortId} has {this._plants.Count} rows of plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}