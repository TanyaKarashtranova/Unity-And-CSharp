using System;
using System.Collections.Generic;
using System.Text;

namespace CakeFactory.CakeFactory
{
    public class Deliverer
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

        public double Tip { get; set; }

        private string name;
        private string telephone;
        private HashSet<Order> orders;
        public static Factory factory;
     
        public Deliverer(string name, string telephone)
        {
            this.Name = name;
            this.telephone = telephone;
            this.orders = new HashSet<Order>();
        }

        public void AddOrder(Order order)
        {
            if (order != null )
            {
                this.orders.Add(order);
            }
            else
            {
                Console.WriteLine("This order has no cakes in it(not enough quantity in Factory) , so we won't add it for deliver.");
            }
        }

        public void BringAllOrders()
        {
            foreach (Order order in orders)
            {
                BringOrder(order);
                Console.Write(this.ToString());
                Console.WriteLine($" bring order with id {order.Id} .");
            }
        }

        public void BringOrder(Order order)
        {
            double priceForCakes = order.Price;
            this.Tip += order.Client.PayTipToDeliverer(priceForCakes);
            factory.Incomes += priceForCakes;
        }

        public override string ToString()
        {
            return $"Deliver with {name} and  telephone {telephone} .";
        }
    }
}
