using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Board
    {
        static string BoardTxtPath = Path.Combine(Program.BasePath, "Board.txt");
        static string BoardLayout = File.ReadAllText(BoardTxtPath);
        public static List<Square> Squares = new List<Square>
        {
            new Square(Coordinate.A1, 10, 1),
            new Square(Coordinate.A2, 7, 1),
            new Square(Coordinate.A3, 4, 1),
            new Square(Coordinate.A4, 1, 1),
            new Square(Coordinate.B1, 10, 3),
            new Square(Coordinate.B2, 7, 3),
            new Square(Coordinate.B3, 4, 3),
            new Square(Coordinate.A1, 1, 3),
            new Square(Coordinate.C1, 1, 2),
            new Square(Coordinate.C2, 4, 2),
            new Square(Coordinate.C3, 7, 2),
            new Square(Coordinate.C4, 10, 2),
            new Square(Coordinate.C5, 13, 2),
            new Square(Coordinate.C6, 16, 2),
            new Square(Coordinate.C7, 19, 2),
            new Square(Coordinate.C8, 22, 2),
            new Square(Coordinate.A5, 22, 1),
            new Square(Coordinate.A6, 19, 1),
            new Square(Coordinate.B5, 22, 3),
            new Square(Coordinate.B6, 19, 3)
        };

        public static void DrawBoard()
        {
            Console.WriteLine(BoardLayout);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(1, 1);
            Console.Write("__");
            Console.SetCursorPosition(19, 1);
            Console.Write("__");
            Console.SetCursorPosition(19, 3);
            Console.Write("__");
            Console.SetCursorPosition(1, 3);
            Console.Write("__");
            Console.SetCursorPosition(13, 2);
            Console.Write("__");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 4);
            Console.WriteLine();
        }
    }
}
