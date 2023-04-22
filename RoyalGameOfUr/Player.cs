using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Player
    {
        public Player(ConsoleColor color)
        {
            Color = color;
            Pieces = new List<Piece>
            {
                new Piece(Board.CoordToSquare[Coordinate.Off], this),
                new Piece(Board.CoordToSquare[Coordinate.Off], this),
                new Piece(Board.CoordToSquare[Coordinate.Off], this),
                new Piece(Board.CoordToSquare[Coordinate.Off], this),
                new Piece(Board.CoordToSquare[Coordinate.Off], this),
                new Piece(Board.CoordToSquare[Coordinate.Off], this),
                new Piece(Board.CoordToSquare[Coordinate.Off], this)
            };
        }

        public ConsoleColor Color { get; set; }
        public List<Piece> Pieces { get; set; }

        public int CountOffPieces()
        {
            var count = 0;
            foreach (var piece in Pieces)
            {
                if (piece.Square == Board.CoordToSquare[Coordinate.Off])
                {
                    count++;
                }
            }
            return count;
        }

        public int CountHomePieces()
        {
            var count = 0;
            foreach (var piece in Pieces)
            {
                if (piece.Square == Board.CoordToSquare[Coordinate.Home])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
