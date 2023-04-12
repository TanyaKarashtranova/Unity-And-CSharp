using CakeFactory.CakeFactory.Cakes;
using CakeFactory.CakeFactory.Clients;
using System;
using System.Collections.Generic;
using static CakeFactory.CakeFactory.Cakes.Cake;

namespace CakeFactory.CakeFactory
{
    public class Factory
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public double Incomes { get; set; }

        private List<Deliverer> deliverers;
        private List<Cake> catalog;
        private SortedDictionary<ChildCake, int> childShowcase;
        private SortedDictionary<SpecialCake, int> specialShowcase;
        private SortedDictionary<StandartCake, int> standartShowcase;
        private SortedDictionary<WeddingCake, int> weddingShowcase;

        public Factory(string name)
        {
            this.Name = name;
            this.Address = "Sofia, str. Bryast 6";
            this.Telephone = "0882999745";
            this.catalog = CreateCatalog();
            this.deliverers = new List<Deliverer>();
            this.childShowcase = new SortedDictionary<ChildCake, int>(new ChildCakeCompare());
            this.specialShowcase = new SortedDictionary<SpecialCake, int>(new SpecialCakeCompare());
            this.standartShowcase = new SortedDictionary<StandartCake, int>(new StandartCakeCompare());
            this.weddingShowcase = new SortedDictionary<WeddingCake, int>(new WeddingCakeCompare());
        }

        private List<Cake> CreateCatalog()
        {
            this.catalog = new List<Cake>();
            this.catalog.AddRange(ChildCake.CreateAllChildCakes());
            this.catalog.AddRange(SpecialCake.CreateAllSpecialCakes());
            this.catalog.AddRange(StandartCake.CreateAllStandartCakes());
            this.catalog.AddRange(WeddingCake.CreateAllWeddingCakes());
            return catalog;
        }

        public void AddDeliverer(Deliverer deliverer)
        {
            if (deliverer != null)
            {
                this.deliverers.Add(deliverer);
            }
            else
            {
                Console.WriteLine("There is no deliverer data ...");
            }
        }

        public List<Deliverer> GetDeliverers()
        {
            return this.deliverers;        
        }

        public void AddChildCakeToChildShowcase(ChildCake cake)
        {  
            if (!this.childShowcase.ContainsKey(cake))
            {
                childShowcase.Add(cake,1);
             }
            else
            {
                this.childShowcase[cake] = this.childShowcase[cake] + 1;
            }
        }

        public void AddSpecialCakeToSpecialShowcase(SpecialCake cake)
        {
            if (!this.specialShowcase.ContainsKey(cake))
            {
                specialShowcase.Add(cake, 1);
            }
            else
            {
                this.specialShowcase[cake] = this.specialShowcase[cake] + 1;
            }
        }

        public void AddStandartCakeToStandartShowcase(StandartCake cake)
        {
            if (!this.standartShowcase.ContainsKey(cake))
            {
                standartShowcase.Add(cake, 1);
            }
            else
            {
                this.standartShowcase[cake] = this.standartShowcase[cake] + 1;
            }
        }

        public void AddWeddingCakeToWeddingShowcase(WeddingCake cake)
        {
            if (!this.weddingShowcase.ContainsKey(cake))
            {
                weddingShowcase.Add(cake, 1);
            }
            else
            {
                this.weddingShowcase[cake] = this.weddingShowcase[cake] + 1;
            }
        }

        public void AddCake(Cake cake)
        {
            if (cake == null)
            {
                Console.WriteLine("There is no cake to be add in showcase.");
            }
            else
            {
                switch (cake.MainType)
                {
                    case Cake.CakeType.Kid:
                        ChildCake cake1 = (ChildCake)cake;
                        AddChildCakeToChildShowcase(cake1);
                        break;
                    case Cake.CakeType.Special:
                        SpecialCake cake2 = (SpecialCake)cake;
                        AddSpecialCakeToSpecialShowcase(cake2);
                        break;
                    case Cake.CakeType.Standart:
                        StandartCake cake3 = (StandartCake)cake;
                        AddStandartCakeToStandartShowcase(cake3);
                        break;
                    case Cake.CakeType.Wedding:
                        WeddingCake cake4 = (WeddingCake)cake;
                        AddWeddingCakeToWeddingShowcase(cake4);
                        break;
                }
            }

        }

        public List<Cake> GetAllCakesInOneCakeTypeFromCatalog(CakeType type)
        {
            List<Cake> cakes = new List<Cake>(); ;
            for (int i = 0; i < catalog.Count; i++)
            {
                if (catalog[i].MainType.Equals(type))
                {
                    cakes.Add(catalog[i]);
                }
            }
            return cakes;
        }

        public Cake GetCakeFromShowcases(Cake cake)
        {
            Cake resposeCake = null ;
                switch (cake.MainType)
                {
                    case Cake.CakeType.Kid:
                        ChildCake cake1 = (ChildCake)cake;
                    if (this.childShowcase.ContainsKey(cake1) && this.childShowcase[cake1] > 0)
                    {
                        this.childShowcase[cake1] = this.childShowcase[cake1] - 1;
                        cake1.ChildName = Utility.GetRandomName();
                        resposeCake = cake1;
                    }
                    break;
                case Cake.CakeType.Special:
                        SpecialCake cake2 = (SpecialCake)cake;
                        if (this.specialShowcase.ContainsKey(cake2) && this.specialShowcase[cake2] > 0)
                        {
                        this.specialShowcase[cake2] = this.specialShowcase[cake2] - 1;
                        cake2.EventName = Utility.GetRandomEventName();
                            return cake2;
                        }
                    break;
                    case Cake.CakeType.Standart:
                        StandartCake cake3 = (StandartCake)cake;
                        if (this.standartShowcase.ContainsKey(cake3) && this.standartShowcase[cake3] > 0)
                        {
                        this.standartShowcase[cake3] = this.standartShowcase[cake3] - 1;
                        return cake3;
                        }
                    break;
                    case Cake.CakeType.Wedding:
                        WeddingCake cake4 = (WeddingCake)cake;
                        if (this.weddingShowcase.ContainsKey(cake4) && this.weddingShowcase[cake4] > 0)
                        {
                        this.weddingShowcase[cake4] = this.weddingShowcase[cake4] - 1;
                        return cake4;
                        }
                     break;
                }
            return resposeCake;
        }

        public List<Cake> FindWhichWantedCakesAreInStock(List<Cake> wantedCakes)
        {
            List<Cake> wantedCakesInStock = new List<Cake>();
            for (int i = 0; i < wantedCakes.Count; i++)
            {
                Cake checkedCake = GetCakeFromShowcases(wantedCakes[i]);
                if (checkedCake != null)
                {
                    wantedCakesInStock.Add(checkedCake);
                }
                else
                {
                    Console.WriteLine("There is no enough quantity from that tipe of Cake. Sorry.");
                }
            }
            if (wantedCakesInStock.Count == 0)
            {
                wantedCakesInStock = null;
            }
            return wantedCakesInStock;
        }

        public double CalculatePriceIncludeDiscount(Order order)
        {
            double initialPrice = order.CalculatePrice(order.GetCakes());
            return order.Client.ApplyDiscount(initialPrice);
        }

        public void TakeOrderFromClient(Order order)
        {
            List<Cake> wantedCakes = order.GetCakes();
            List<Cake> orderCakes = FindWhichWantedCakesAreInStock(wantedCakes);
            if (orderCakes != null)
            {
                order.SetCakes(orderCakes);
                order.Price = CalculatePriceIncludeDiscount(order);
                List<Deliverer> deliverers = GetDeliverers();
                int radnomIndex = Utility.GetRandomInt(0, deliverers.Count);
                Deliverer deliver = deliverers[radnomIndex];
                if (order != null)
                {
                    Console.WriteLine(order.ToString());
                    order.PrintCakeOrder();
                    deliver.AddOrder(order);
                    Console.WriteLine();
                }
            }
            else 
            {
                Console.WriteLine($"Sorry.Order with id {order.Id} won't be complete. We don't have cake for your taste in stock.");
            }
        }

        public void  ShowChildCakesInChildShowcase()
        {
            foreach (var item in childShowcase)
            {
                Console.WriteLine($"{item.Key.ToString()} with number of available items = {item.Value}");
            }
        }

        public void ShowStandartCakesFromStandarthowcase()
        {
            foreach (var item in standartShowcase)
            {
                Console.WriteLine($"{item.Key.ToString()} with number of available items = {item.Value}");
            }
        }

        public void ShowWeddingCakesFromWeddingShowcase()
        {
            foreach (var item in weddingShowcase)
            {
                Console.WriteLine($"{item.Key.ToString()} with number of available items = {item.Value}");
            }
        }

        public void ShowSpecialCakesFromSpecialShowcase()
        {
            foreach (var item in specialShowcase)
            {
                Console.WriteLine($"{item.Key.ToString()} with number of available items = {item.Value}");
            }
        }

        public void ShowAllCakesInShowcases()
        {            
            ShowChildCakesInChildShowcase();
            Console.WriteLine();
            ShowSpecialCakesFromSpecialShowcase();
            Console.WriteLine();
            ShowStandartCakesFromStandarthowcase();
            Console.WriteLine();
            ShowWeddingCakesFromWeddingShowcase();
        }
    }
}
