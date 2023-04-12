using System;
using System.Collections.Generic;
using System.Text;
using CakeFactory.CakeFactory.Cakes;

namespace CakeFactory.CakeFactory.Cakes
{
    public class WeddingCake : Cake
    {
        public enum WeddingCakeSubType
        {
            Big,
            Middle,
            Small
        }

        public WeddingCakeSubType CakeSubType { get; set; }

        public int Floors { get; set; }

        public WeddingCake(string name, string description, double price, int pieces, WeddingCakeSubType cakeSubType, int floors) : base(name, description, price, pieces, CakeType.Wedding)
        {
            this.Floors = floors;
            this.CakeSubType = cakeSubType;
        }

        public static List<WeddingCake> CreateAllWeddingCakes()
        {
            List<WeddingCake> weddingCakes = new List<WeddingCake>();
            WeddingCake cake = new WeddingCake("Golden marbel", " Cake choco mouse.", Utility.GetRandomDouble(50, 350), Utility.GetRandomInt(15, 120), WeddingCakeSubType.Big, Utility.GetRandomInt(1, 5));
            weddingCakes.Add(cake);
            WeddingCake cake1 = new WeddingCake("Garden marbel", "Cake  choco mouse.", Utility.GetRandomDouble(50, 250), Utility.GetRandomInt(15, 100), WeddingCakeSubType.Middle, Utility.GetRandomInt(1, 3));
            weddingCakes.Add(cake1);
            WeddingCake cake2 = new WeddingCake("Soft moments", "Cake  choco mouse.", Utility.GetRandomDouble(50, 200), Utility.GetRandomInt(10, 50), WeddingCakeSubType.Small, Utility.GetRandomInt(1, 2));
            weddingCakes.Add(cake2);
            return weddingCakes;
        }

        public override string ToString()
        {
            return $"Type : {base.MainType}  Subtype: {CakeSubType}" +
                $" {base.Name} {base.Description}  with price =  {base.Price.ToString("N2")}  and piece = {base.Pieces}";
        }
    } 
}
