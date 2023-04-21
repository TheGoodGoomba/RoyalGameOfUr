using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Dice
    {
        private static Random _rng = new Random();

        public static int Roll()
        {
            var die1 = _rng.Next(0, 2);
            var die2 = _rng.Next(0, 2);
            var die3 = _rng.Next(0, 2);
            var die4 = _rng.Next(0, 2);
            return die1 + die2 + die3 + die4;
        }
    }
}
