using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<Chicken>
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();

        private List<Chicken> _animals = new List<Chicken>();

        public double Capacity {
            get {
                return _capacity;
            }
        }
        public List<Chicken> animalsList {
            get {
                return _animals;
            }
        }

        public void AddResource (Chicken animal, Farm farm)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(animal);
            }
            else {
                ChooseChickenHouse.atCapacity = true;
                ChooseChickenHouse.CollectInput(farm, animal);
            }
        }

         public void AddResource (Chicken animal)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(animal);
            }
        }

        public void AddResource (List<Chicken> animals)  // TODO: Take out this method for boilerplate
        {
            if (_animals.Count + animals.Count <= _capacity) {
                _animals.AddRange(animals);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Chicken House {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}