using System;
using System.Collections.Generic;
using System.Text;
using static CakeFactory.CakeFactory.Cakes.ChildCake;

namespace CakeFactory.CakeFactory.Cakes
{
    public abstract class Cake
    {
        public static Factory factory;
        public enum CakeType {
            Standart,
            Wedding,
            Special,
            Kid
        }

        public double Price
        {
            get { return price; }
            protected set
            {
                if (value < 1)
                {
                    Console.WriteLine("You can't sell cake for 0 leva.");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public int Pieces
        {
            get { return this.pieces; }
            protected set
            {
                if (value < 0 || value > 200)
                {
                    Console.WriteLine("Uncorrect number for pieces of Cake.");
                }
                else
                {
                    this.pieces = value;
                }
            }
        }

        protected string Name
        {
            get { return this.name; }
            set
            {
                if (!Utility.ValidateString(value))
                {
                    Console.WriteLine("This name is not good for cake.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        protected string Description
        {
            get { return this.description; }
            set
            {
                if (!Utility.ValidateString(value))
                {
                    Console.WriteLine("This text is not ok for description for cake.");
                }
                else
                {
                    this.description = value;
                }
            }
        }

        public CakeType MainType { get; set; }
        private string name;
        private string description;
        private double price;
        private int pieces;
                         
        public Cake(string name, string description, double price, int pieces, CakeType type)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Pieces  = pieces;
            this.MainType = type;
        }

        public static CakeType GetRandomCakeType()
        {
            Array values = CakeType.GetValues(typeof(CakeType));
            Random random = new Random();
            int i = random.Next(values.Length);
            CakeType randomCakeType = (CakeType)values.GetValue(i);
            return randomCakeType;
        }

    }
}
