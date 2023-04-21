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

        public void Move(Square newSquare)
        {
            Square.Piece = null;
            Square = null;
            Console.SetCursorPosition(newSquare.Left, newSquare.Top);
            Console.BackgroundColor = Player.Color;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 5);
            Square = newSquare;
        }
    }
}
