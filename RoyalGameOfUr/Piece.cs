using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Piece
    {
        public Piece(Coordinate pos, ConsoleColor color)
        {
            Position = pos;
            Color = color;
        }

        public Coordinate Position { get; set; }
        public ConsoleColor Color { get; set; }

        public void Move(Coordinate newPosition)
        {
            var square = Board.Squares.Find(x => x.Coordinates == newPosition);
            Console.SetCursorPosition(square.Left, square.Top);
            Console.BackgroundColor = Color;
            Console.Write("_");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 5);
            Position = newPosition;
        }
    }
}
