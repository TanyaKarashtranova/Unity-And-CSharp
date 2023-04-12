using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CakeFactory.CakeFactory.Cakes
{
    public class ChildCakeCompare : IComparer<ChildCake>
    {
        public int Compare(ChildCake firstCake, ChildCake secondCake)
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
