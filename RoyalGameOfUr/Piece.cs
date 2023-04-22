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

        public void Move(Square newSquare, string text)
        {
            var cursorReturn = Console.GetCursorPosition();
            Console.SetCursorPosition(Square.Left, Square.Top);
            Console.Write(" ");
            //if (toSave)
            //{
                Square.Piece = null;
                Square = newSquare;
            //}
            Console.SetCursorPosition(newSquare.Left, newSquare.Top);
            Console.BackgroundColor = Player.Color;
            Console.Write(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(cursorReturn.Left, cursorReturn.Top);
            // TODO MAKE IT SO THAT THE * STAYS ON ROSETTES.
        }

        public void Remove(bool isHome)
        {
            // can use this later for taking pieces off when they are home.
            var cursorReturn = Console.GetCursorPosition();
            Console.SetCursorPosition(Square.Left, Square.Top);
            Console.Write(" ");
            Square.Piece = null;
            if (!isHome)
            {
                Square = Board.CoordToSquare[Coordinate.Off];
            }
            Console.SetCursorPosition(cursorReturn.Left, cursorReturn.Top);
        }
    }
}
