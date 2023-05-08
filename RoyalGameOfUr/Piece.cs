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
            Square.Pieces.Remove(this);
            if (destination.Pieces.Count == 1 && destination != Board.CoordToSquare[Coordinate.Home]) //i.e. remove other player's piece
            {
                destination.Pieces[0].Square = Board.CoordToSquare[Coordinate.Off];
                destination.Pieces.RemoveAt(0);
            }
            destination.Pieces.Add(this);
            Square = destination;
            Board.DrawBoardInfo();
        }
    }
}
