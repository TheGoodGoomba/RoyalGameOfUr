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
        public static List<Coordinate> Player1SquareSequence = new List<Coordinate>
        {
            Coordinate.A1, Coordinate.A2, Coordinate.A3, Coordinate.A4, Coordinate.C1, Coordinate.C2, Coordinate.C3, Coordinate.C4, Coordinate.C5, Coordinate.C6, Coordinate.C7, Coordinate.C8, Coordinate.A5, Coordinate.A6
        };
        public static List<Coordinate> Player2SquareSequence = new List<Coordinate>
        {
            Coordinate.B1, Coordinate.B2, Coordinate.B3, Coordinate.B4, Coordinate.C1, Coordinate.C2, Coordinate.C3, Coordinate.C4, Coordinate.C5, Coordinate.C6, Coordinate.C7, Coordinate.C8, Coordinate.B5, Coordinate.B6
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
            Console.SetCursorPosition(1, 6);
            Console.WriteLine();
        }

        public static bool Player1EntranceSpotFree(int diceRoll)
        {
            switch (diceRoll)
            {
                case 1:
                    if (!Board.Squares.Find(x => x.Coordinates == Coordinate.A1).HasPiece)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (!Board.Squares.Find(x => x.Coordinates == Coordinate.A2).HasPiece)
                    {
                        return true;
                    }
                    break;
                case 3:
                    if (!Board.Squares.Find(x => x.Coordinates == Coordinate.A3).HasPiece)
                    {
                        return true;
                    }
                    break;
                case 4:
                    if (!Board.Squares.Find(x => x.Coordinates == Coordinate.A4).HasPiece)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool Player2EntranceSpotFree(int diceRoll)
        {
            switch (diceRoll)
            {
                case 1:
                    if (!Board.Squares.Find(x => x.Coordinates == Coordinate.B1).HasPiece)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (!Board.Squares.Find(x => x.Coordinates == Coordinate.B2).HasPiece)
                    {
                        return true;
                    }
                    break;
                case 3:
                    if (!Board.Squares.Find(x => x.Coordinates == Coordinate.B3).HasPiece)
                    {
                        return true;
                    }
                    break;
                case 4:
                    if (!Board.Squares.Find(x => x.Coordinates == Coordinate.B4).HasPiece)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
