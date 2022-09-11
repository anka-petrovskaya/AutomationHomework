using System;
using System.Xml.Serialization;

namespace EntryTasks.Task2.Objects
{
    [Serializable]
    [XmlInclude(typeof(Rose))]
    [XmlInclude(typeof(Tulip))]
    [XmlInclude(typeof(Violet))]
    public abstract class Flower
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int Length { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Color: {Color}, Length: {Length}cm, Price: {Price}$.";
        }
    }
    public class Rose : Flower
    {
        public Rose()
        {
            Name = "Rose";
            Color = "Red";
            Price = 10;
            Length = 15;
        }
    }
    public class Tulip : Flower
    {
        public Tulip()
        {
            Name = "Tulip";
            Color = "Yellow";
            Price = 20;
            Length = 25;
        }
    }
    public class Violet : Flower
    {
        public Violet()
        {
            Name = "Violet";
            Color = "Blue";
            Price = 30;
            Length = 35;
        }
    }
}