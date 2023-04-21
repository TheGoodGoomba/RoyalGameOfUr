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
            new Square(Coordinate.A1, 14, 1),
            new Square(Coordinate.A2, 10, 1),
            new Square(Coordinate.A3, 6, 1),
            new Square(Coordinate.A4, 2, 1),
            new Square(Coordinate.B1, 14, 5),
            new Square(Coordinate.B2, 10, 5),
            new Square(Coordinate.B3, 6, 5),
            new Square(Coordinate.B4, 2, 5),
            new Square(Coordinate.C1, 2, 3),
            new Square(Coordinate.C2, 6, 3),
            new Square(Coordinate.C3, 10, 3),
            new Square(Coordinate.C4, 14, 3),
            new Square(Coordinate.C5, 18, 3),
            new Square(Coordinate.C6, 22, 3),
            new Square(Coordinate.C7, 26, 3),
            new Square(Coordinate.C8, 30, 3),
            new Square(Coordinate.A5, 30, 1),
            new Square(Coordinate.A6, 26, 1),
            new Square(Coordinate.B5, 30, 5),
            new Square(Coordinate.B6, 26, 5)
        };

        public static void DrawBoard()
        {
            Console.WriteLine(BoardLayout);
            var rosettes = new List<Coordinate>
            {
                Coordinate.A4, Coordinate.B4, Coordinate.C4, Coordinate.A6, Coordinate.B6
            };
            Console.BackgroundColor = ConsoleColor.Magenta;
            foreach (var r in rosettes)
            {
                var square = Squares.Find(x => x.Coordinates == r);
                Console.SetCursorPosition(square.Left - 1, square.Top);
                Console.Write(" * ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(7, 1);
            Console.WriteLine();
        }
    }
}
