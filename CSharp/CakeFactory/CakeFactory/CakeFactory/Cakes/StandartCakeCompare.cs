using System;
using System.Collections.Generic;
using System.Text;

namespace CakeFactory.CakeFactory.Cakes
{
    public class StandartCakeCompare : IComparer<StandartCake>
    {
        public int Compare(StandartCake firstCake, StandartCake secondCake)
        {
            if (secondCake.Price.CompareTo(firstCake.Price) != 0)
            {
                return secondCake.Price.CompareTo(firstCake.Price);
            }
            else
            {
                return 0;
            }
        }
    }
}
