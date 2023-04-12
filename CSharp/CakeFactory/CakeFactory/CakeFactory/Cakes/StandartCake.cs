using System;
using System.Collections.Generic;
using System.Text;

namespace CakeFactory.CakeFactory.Cakes
{
   public class StandartCake : Cake
    {
        public enum StandartCakeSubType
        {
            Biskuit,
            Eclair,
            Fruit,
            Chocolate
        }

        public StandartCakeSubType CakeSubType { get; set; }

        private bool hasSirop;
       
        public StandartCake(string name, string description, double price, int pieces, StandartCakeSubType cakeSubType) : base(name, description, price, pieces, CakeType.Standart)
        {
            this.hasSirop = Utility.GetRandomBoolean();
            this.CakeSubType = cakeSubType;
        }
   
        public static List<StandartCake> CreateAllStandartCakes()
        {
            List<StandartCake> standartCakes = new List<StandartCake>();
            StandartCake cake = new StandartCake("Banofi Taft", "Cake with choco biscuit, caramel and bananas  ",Utility.GetRandomDouble(80,150), Utility.GetRandomInt(10, 40), StandartCakeSubType.Biskuit);
            standartCakes.Add(cake);
            StandartCake cake1 = new StandartCake("Lind", "Cake with milk chocolate, white chocolate, nuts and buscuits.", Utility.GetRandomDouble(50, 250), Utility.GetRandomInt(15, 40), StandartCakeSubType.Chocolate);
            standartCakes.Add(cake1);
            StandartCake cake2 = new StandartCake("Eclair rasspberry", "Cake with rasspberry ,eclairs and cream.", Utility.GetRandomDouble(50, 200), Utility.GetRandomInt(10, 30), StandartCakeSubType.Eclair);
            standartCakes.Add(cake2);
            StandartCake cake3 = new StandartCake("Pavlova", "Cake with fresh strawberries, apples,bannas, kiwis,oranges and creams .", Utility.GetRandomDouble(50, 200), Utility.GetRandomInt(10, 30), StandartCakeSubType.Fruit);
            standartCakes.Add(cake3);
            return standartCakes;
        }

        public override string ToString()
        {
            return $"Type : {base.MainType}  Subtype: {CakeSubType}" +
                $" {base.Name} {base.Description}  with price =  {base.Price.ToString("N2")}  and piece = {base.Pieces}";
        }
    }
}
