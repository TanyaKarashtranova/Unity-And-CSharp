using CakeFactory.CakeFactory;
using CakeFactory.CakeFactory.Cakes;
using CakeFactory.CakeFactory.Clients;
using System;
using System.Collections.Generic;
using static CakeFactory.CakeFactory.Cakes.Cake;

namespace CakeFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory("Sweet Talents");
            Foodpanda.factory = factory;
            Deliverer.factory = factory;

            for (int i = 0; i < 5; i++)
            {
                Deliverer deliver = new Deliverer(Utility.GetRandomName(), Utility.GetRandomTelephone());
                factory.AddDeliverer(deliver);
            }

            for (int i = 0; i < 30; i++)
            {
                CakeType type = Cake.GetRandomCakeType();
                List<Cake> cakes = factory.GetAllCakesInOneCakeTypeFromCatalog(type);
                Cake cake = cakes[Utility.GetRandomInt(0, cakes.Count)];
                factory.AddCake(cake);
            }

            Console.WriteLine("--------------SHOWCASES--------------");
            factory.ShowAllCakesInShowcases();
            Console.WriteLine();
            List<Client> clients = new List<Client>();

            for (int i = 0; i < 5; i++)
            {
                PrivateClient client = new PrivateClient(Utility.GetRandomName(), Utility.GetRandomTelephone());
                clients.Add(client);
            }

            for (int i = 0; i < 5; i++)
            {
                BisinessClient client1 = new BisinessClient(Utility.GetRandomName(), Utility.GetRandomTelephone());
                clients.Add(client1);
            }

            for (int i = 0; i < clients.Count; i++)
            {
                factory.TakeOrderFromClient(clients[i].MakeOrder());
            }

            foreach (Deliverer deliverer in factory.GetDeliverers())
            {
                deliverer.BringAllOrders();
            }

            Console.WriteLine();
            Console.WriteLine("--------------SHOWCASES--------------");
            factory.ShowAllCakesInShowcases();
            Console.WriteLine();
            Console.WriteLine($"Money in the Factory from orders {factory.Incomes.ToString("N2")}");
        }
    }
}
