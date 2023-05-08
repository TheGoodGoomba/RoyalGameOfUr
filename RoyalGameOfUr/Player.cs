using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Player
    {
        public Player(ConsoleColor bgColor, ConsoleColor textColor)
        {
            BgColor = bgColor;
            TextColor = textColor;
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
            HasWon = false;
        }

        public ConsoleColor BgColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        public List<Piece> Pieces { get; set; }
        public bool HasWon { get; set; }

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
