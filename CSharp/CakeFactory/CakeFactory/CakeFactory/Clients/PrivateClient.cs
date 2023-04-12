using CakeFactory.CakeFactory.Cakes;
using System;
using System.Collections.Generic;
using System.Text;
using static CakeFactory.CakeFactory.Cakes.Cake;

namespace CakeFactory.CakeFactory.Clients
{
    public class PrivateClient : Client
    {
        private const int MinNumberOrders = 1;
        private const int MaxNumberOrders = 3;
        protected const double PercentTip = 0.02;
        public PrivateClient(string name, string telephone) : base(name, telephone)
        {
        }

        public override Order MakeOrder()
        {
            List<Cake> wantedCakes = ChooseCakeForOrder(base.minNumberOrder, base.maxNumberOrder);
            Order order = new Order(this, Utility.GetRandomAddress(), wantedCakes);
            return order;
        }

        protected override int GetMaxNumberOrders()
        {
            return MaxNumberOrders;
        }

        protected override int GetMinNumberOrders()
        {
            return MinNumberOrders;
        }

        protected override double GetPercentTip()
        {
            return PercentTip;
        }

        protected override double GetDiscount()
        {
           return Utility.CalculatePrivateClientDiscount();
        }

        public override double ApplyDiscount(double price)
        {
            double result = price - Discount;
            if (result < 0)
            {
                result = 0;
            }
            return result;
        }
    }
}
