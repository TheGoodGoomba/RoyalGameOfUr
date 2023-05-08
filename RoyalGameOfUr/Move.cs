using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Move
    {
        public Move(Piece piece, Square destination, char id)
        {
            Piece = piece;
            Destination = destination;
            Identifier = id;
        }

        public Piece Piece { get; set; }
        public Square Destination { get; set; }
        public char Identifier { get; set; }
    }
}
