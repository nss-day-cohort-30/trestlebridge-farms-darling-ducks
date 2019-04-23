using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class NaturalField
    {
        private int _capacity = 10;
        private Guid _id = Guid.NewGuid();

        private List<ICompostProducing> _plants = new List<ICompostProducing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }
        public List<ICompostProducing> plantsList {
            get {
                return _plants;
            }
        }

        public void AddResource (ICompostProducing plant, Farm farm)
        {
            if (_plants.Count < _capacity) {
                _plants.Add(plant);
            }
            else {
                ChooseNaturalField.atCapacity = true;
                ChooseNaturalField.CollectInput(farm, plant);
            }
        }

         public void AddResource (ICompostProducing plant)
        {
            if (_plants.Count < _capacity) {
                _plants.Add(plant);
            }
        }

        public void AddResource (List<ICompostProducing> plants)  // TODO: Take out this method for boilerplate
        {
            if (_plants.Count + plants.Count <= _capacity) {
                _plants.AddRange(plants);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this._plants.Count} row(s) of plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}