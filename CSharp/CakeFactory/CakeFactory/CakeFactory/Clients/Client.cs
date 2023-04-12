using CakeFactory.CakeFactory.Cakes;
using System;
using System.Collections.Generic;
using System.Text;
using static CakeFactory.CakeFactory.Cakes.Cake;

namespace CakeFactory.CakeFactory.Clients
{
    public abstract class Client
    {
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("The name of suplier can't be null.");
                }
                else
                {
                    this.name = value;
                }

            }
        }

        public double Discount { get; set; }

        protected int minNumberOrder;
        protected int maxNumberOrder;
        public double percentTip;
        private string name;
        private string telephone;
 
        public Client(string name, string telephone)
        {
            this.Name = name;
            this.telephone = telephone;
            this.minNumberOrder = GetMinNumberOrders();
            this.maxNumberOrder = GetMaxNumberOrders();
            this.percentTip = GetPercentTip();
            this.Discount = GetDiscount();
        }

        public abstract Order MakeOrder();

        public List<Cake> ChooseCakeForOrder(int min, int max) 
        {
            List<Cake> wantedCakes = new List<Cake>();
            int cakeNum = Utility.GetRandomInt(min, max);
            for (int i = 0; i < cakeNum; i++)
            {
                CakeType type = Cake.GetRandomCakeType();
                List<Cake> cakes = Foodpanda.GetAllTheCakesInOneCakeTypeInFactory(type);
                Cake cake = cakes[Utility.GetRandomInt(0, cakes.Count)];
                wantedCakes.Add(cake);
            }
            return wantedCakes;
        }

        public override string ToString()
        {
            return $" Client with name  {name} telephone {telephone} and discount {Discount.ToString("N2")}.";
        }

        protected abstract int GetMinNumberOrders();

        protected abstract int GetMaxNumberOrders();

        protected abstract double GetPercentTip();

        protected abstract double GetDiscount();

        public abstract double ApplyDiscount(double price);

        public double PayTipToDeliverer(double price)
        {
            return price * this.percentTip;
        }
    }
}
