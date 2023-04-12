using CakeFactory.CakeFactory.Cakes;
using CakeFactory.CakeFactory.Clients;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CakeFactory.CakeFactory
{
    public class Order : IEquatable<Order>
    {
        public Client Client
        {
            get
            {
                return this.client;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("There is no client to make order.");
                }
                else
                {
                    this.client = value;
                }
            }
        }

        public string DeliveryAddress
        {
            get
            {
                return this.deliveryAddress;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Can't create a order without address!");
                }
                else
                {
                    this.deliveryAddress = value;
                }
            }
        }

        public DateTime DeliveryDate { get; set; }

        public double Price { get; set; }

        public int Id { get; set; }

        private Client client;       
        private string deliveryAddress;
        private List<Cake> cakes = new List<Cake>();
        
        public Order(Client client, string deliveryAddress, List<Cake> cakes)
        {
            this.Id = Utility.GetOrderId();
            this.Client = client;
            this.DeliveryAddress = deliveryAddress;
            this.DeliveryDate = DateTime.Now.AddHours(24);
            this.cakes.AddRange(cakes);
        }

        public double CalculatePrice(List<Cake> cakes)
        {
            double result = 0;
            if (cakes.Count == 0)
            {
                this.Price = 0;
            }
            else
            {
                for (int i = 0; i < cakes.Count; i++)
                {
                    result += cakes[i].Price;
                }
            }
            return result;
        }

        public override string ToString()
        {
            return $"{client.ToString()} make a order with id {Id} for adrress  {DeliveryAddress} till delivery Date {DeliveryDate}. ";
        }

        public List<Cake> GetCakes()
        {
            return this.cakes;
        }

        public void SetCakes(List<Cake> cakes)
        {
            this.cakes = cakes;
        }

        public void PrintCakeOrder()
        {
            for (int i = 0; i < this.cakes.Count; i++)
            {
                Console.WriteLine(cakes[i].ToString());
            }
        }

        public bool Equals( Order other)
        {
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
