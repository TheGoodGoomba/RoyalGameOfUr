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
                new Piece(Coordinate.Off, Color),
                new Piece(Coordinate.Off, Color),
                new Piece(Coordinate.Off, Color),
                new Piece(Coordinate.Off, Color),
                new Piece(Coordinate.Off, Color),
                new Piece(Coordinate.Off, Color),
                new Piece(Coordinate.Off, Color)
            };
        }

        public ConsoleColor Color { get; set; }
        public List<Piece> Pieces { get; set; }
    }
}
