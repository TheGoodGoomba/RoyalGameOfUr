using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Square
    {
        public Square(/*Coordinate coord, */int left, int top)
        {
            //Coordinates = coord;
            Left = left;
            Top = top;
        }

        //public Coordinate Coordinates { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        //public bool HasPiece { get; set; }
        public Piece Piece { get; set; }
    }
}
