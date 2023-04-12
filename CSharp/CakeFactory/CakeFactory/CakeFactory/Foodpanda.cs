using CakeFactory.CakeFactory.Cakes;
using System;
using System.Collections.Generic;
using System.Text;
using static CakeFactory.CakeFactory.Cakes.Cake;

namespace CakeFactory.CakeFactory
{
    public abstract class Foodpanda
    {

        public static Factory factory;

        public static List<Cake> GetAllTheCakesInOneCakeTypeInFactory(CakeType type)
        {
            return factory.GetAllCakesInOneCakeTypeFromCatalog(type);
        }
    }
}
