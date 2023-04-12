using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using CakeFactory.CakeFactory.Cakes;

namespace CakeFactory.CakeFactory.Cakes
{
    public class ChildCake : Cake
    {
        public enum ChildCakeSubType
        {
            BirthdayDay,
            Baptism,
            Snapper
        }

        public string ChildName
        {
            get { return this.childName; }
            set
            {
                if (!Utility.ValidateString(value))
                {
                    Console.WriteLine("Not good name for child.");
                }
                else
                {
                    this.childName = value;
                }
            }
        }

        public ChildCakeSubType CakeSubType { get; set; }

        private string childName;

        public ChildCake(string name, string description, double price, int pieces, ChildCakeSubType subType) : base(name, description, price, pieces, CakeType.Kid)
        {
            this.CakeSubType = subType;
        }
              
        public static List<ChildCake> CreateAllChildCakes()
        {
            List<ChildCake> childCakes = new List<ChildCake>();
            ChildCake cake = new ChildCake("Yogurt", "Child Cake for baptism with yogurt and strawberry", Utility.GetRandomDouble(10, 150), Utility.GetRandomInt(10, 40), ChildCakeSubType.Baptism);
            childCakes.Add(cake);
            ChildCake cake1 = new ChildCake("Choko", "Child Cake for BirthdayDay with Chokolade and Bunnies", Utility.GetRandomDouble(10, 150), Utility.GetRandomInt(10, 40), ChildCakeSubType.BirthdayDay);
            childCakes.Add(cake1);
            ChildCake cake2 = new ChildCake("DayDream", "Child Cake for Snapper with fruits , white Chocolate and cream ", Utility.GetRandomDouble(10, 150), Utility.GetRandomInt(10, 40), ChildCakeSubType.Snapper);
            childCakes.Add(cake2);
            return childCakes;
        }

        public override string ToString()
        {
            return $"Type : {base.MainType} SubType: {CakeSubType}" +
                $" {base.Name} {base.Description}  with price =  {base.Price.ToString("N2")}  and piece = {base.Pieces} ";
        }        
    }
}


