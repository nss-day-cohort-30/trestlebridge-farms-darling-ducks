using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class DuckHouse : IFacility<Duck>
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();

        private List<Duck> _animals = new List<Duck>();

        public double Capacity {
            get {
                return _capacity;
            }
        }
        public List<Duck> animalsList {
            get {
                return _animals;
            }
        }

        public void AddResource (Duck animal, Farm farm)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(animal);
            }
            else {
                ChooseDuckHouse.atCapacity = true;
                ChooseDuckHouse.CollectInput(farm, animal);
            }
        }

         public void AddResource (Duck animal)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(animal);
            }
        }

        public void AddResource (List<Duck> animals)  // TODO: Take out this method for boilerplate
        {
            if (_animals.Count + animals.Count <= _capacity) {
                _animals.AddRange(animals);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._animals.Count} animal(s)\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}