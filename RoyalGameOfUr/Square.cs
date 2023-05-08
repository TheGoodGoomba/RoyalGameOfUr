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
            Pieces = new List<Piece>();
        }

        public int Left { get; set; }
        public int Top { get; set; }
        public List<Piece> Pieces { get; set; }
    }
}
