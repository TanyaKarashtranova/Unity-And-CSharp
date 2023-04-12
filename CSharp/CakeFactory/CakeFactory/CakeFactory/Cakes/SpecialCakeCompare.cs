using System;
using System.Collections.Generic;
using System.Text;

namespace CakeFactory.CakeFactory.Cakes
{
   public class SpecialCakeCompare : IComparer<SpecialCake>
    {
        public int Compare(SpecialCake firstCake, SpecialCake secondCake)
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

