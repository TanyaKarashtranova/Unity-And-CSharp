using CakeFactory.CakeFactory.Cakes;
using System;
using System.Collections.Generic;
using System.Text;
using static CakeFactory.CakeFactory.Cakes.Cake;

namespace CakeFactory.CakeFactory.Clients
{
    public class BisinessClient : Client
    {

        protected const int MinNumberOrders = 3;
        protected const int MaxNumberOrders = 5;
        protected const double PercentTip = 0.05;
        protected const double Discout = 0.9;
        public BisinessClient(string name, string telephone) : base(name, telephone)
        {
        }

        public override Order MakeOrder()
        {
            List<Cake> wantedCakes = ChooseCakeForOrder(base.minNumberOrder, base.maxNumberOrder);
            Order order = new Order(this, Utility.GetRandomAddress(), wantedCakes);
            return order;
        }

        protected override double GetDiscount()
        {
            return Discout;
        }

        protected override int GetMaxNumberOrders()
        {
          return  MaxNumberOrders;
        }

        protected override int GetMinNumberOrders()
        {
            return MinNumberOrders;
        }

        protected override double GetPercentTip()
        {
            return PercentTip;
        }
        
        public override double ApplyDiscount(double price)
        {
            return price * Discount;
        }
    }
}
