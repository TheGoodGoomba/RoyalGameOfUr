using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Piece
    {
        public Piece(Square square, Player player)
        {
            Square = square;
            Player = player;
        }

        public Player Player { get; set; }
        public Square Square { get; set; }

        public void Move(Square destination)
        {
            Square.Piece = null;
            if (destination.Piece != null) //i.e. remove other player's piece
            {
                destination.Piece.Square = Board.CoordToSquare[Coordinate.Off];
            }
            destination.Piece = this;
            Square = destination;
            Board.DrawBoardInfo();
        }
    }
}
