using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EntryTasks.Task2.Objects
{
    [Serializable]
    public class Buket : IEnumerable<Flower>
    {
        private readonly List<Flower> flowers = new List<Flower>();
        public void AddFlower(string flower)
        {
            switch (flower)
            {
                case "Rose":
                    flowers.Add(new Rose());
                    break;
                case "Tulip":
                    flowers.Add(new Tulip());
                    break;
                case "Violet":
                    flowers.Add(new Violet());
                    break;
                default:
                    throw new Exception("Flower doesn't exist");
            }
        }
        public void AddRoses(uint count)
        {
            for (int i = 0; i < count; i++)
                flowers.Add(new Rose());
        }
        public void AddTulips(uint count)
        {
            for (int i = 0; i < count; i++)
                flowers.Add(new Tulip());
        }
        public void AddViolets(uint count)
        {
            for (int i = 0; i < count; i++)
                flowers.Add(new Violet());
        }
        public int GetPrice() => flowers.Sum(f => f.Price);
        public IEnumerator<Flower> GetEnumerator() => flowers.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}