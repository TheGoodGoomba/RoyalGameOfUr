using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Square
    {
        public Square(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public int Left { get; set; }
        public int Top { get; set; }
        public Piece Piece { get; set; }
    }
}
