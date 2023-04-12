using System;
using System.Collections.Generic;
using System.Text;

namespace CakeFactory.CakeFactory.Cakes
{
   public class SpecialCake : Cake
    {
        public enum SpecialCakeSubType
        {
            Jubilee,
            Advertising,
            Company
        }

        public string EventName
        {
            get { return this.eventName; }
            set
            {
                if (!Utility.ValidateString(value))
                {
                    Console.WriteLine("Not good name for eventName.");
                }
                else
                {
                    this.eventName = value;
                }
            }
        }

        public SpecialCakeSubType CakeSubType { get; set; }

        private string eventName;
       
        public SpecialCake(string name, string description, double price, int pieces, SpecialCakeSubType cakeSubType) : base(name, description, price, pieces, CakeType.Special)
        {
            this.CakeSubType = cakeSubType;
        }    

        public static List<SpecialCake> CreateAllSpecialCakes()
        {
            List<SpecialCake> specialCakes = new List<SpecialCake>();
            SpecialCake cake = new SpecialCake("Rasspberry Charlots", " Cake for Advertising with rasspberrry and cream.", Utility.GetRandomDouble(50, 350), Utility.GetRandomInt(15, 120), SpecialCakeSubType.Advertising);
            specialCakes.Add(cake);
            SpecialCake cake1 = new SpecialCake("Mouse", "Cake for Company event with fruits ,nuts and  cream.", Utility.GetRandomDouble(50, 250), Utility.GetRandomInt(15,100), SpecialCakeSubType.Company);
            specialCakes.Add(cake1);
            SpecialCake cake2 = new SpecialCake("Garash", "Cake for Jubilee with nuts ,chocolate.", Utility.GetRandomDouble(50,200), Utility.GetRandomInt(10, 50), SpecialCakeSubType.Jubilee);
            specialCakes.Add(cake2);
            return specialCakes;
        }

        public override string ToString()
        {
            return $"Type : {base.MainType}  Subtype: {CakeSubType}" +
                $" {base.Name} {base.Description}  with price =  {base.Price.ToString("N2")}  and piece = {base.Pieces}";
        }
    }
}
