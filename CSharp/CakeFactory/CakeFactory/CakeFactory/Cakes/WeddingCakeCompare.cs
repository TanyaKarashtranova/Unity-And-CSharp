using System;
using System.Collections.Generic;
using System.Text;

namespace CakeFactory.CakeFactory.Cakes
{
    class WeddingCakeCompare : IComparer<WeddingCake>
    {
        public int Compare(WeddingCake firstCake, WeddingCake secondCake)
        {
            if (firstCake.Pieces.CompareTo(secondCake.Pieces) != 0)
            {
                return firstCake.Pieces.CompareTo(secondCake.Pieces);
            }
            else
            {
                return 0;
            }
        }
    }
}

