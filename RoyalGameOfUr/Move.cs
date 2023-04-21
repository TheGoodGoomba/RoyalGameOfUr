using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Move
    {
        public Move(Piece piece, Square destination)
        {
            Piece = piece;
            Destination = destination;
        }

        public Piece Piece { get; set; }
        public Square Destination { get; set; }
        public int Identifier { get; set; }
    }
}
