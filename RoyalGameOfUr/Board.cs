using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Board
    {
        static string BoardInfoTxtPath = Path.Combine(Program.BasePath, "BoardInfo.txt");
        static string BoardInfoLayout = File.ReadAllText(BoardInfoTxtPath);

        private static Random _rng = new Random();
        private static bool _die1Value = false;
        private static bool _die2Value = false;
        private static bool _die3Value = false;
        private static bool _die4Value = false;
        private static int _diceCount = 0;

        static string Message;
        static string Instructions;

        public static List<Square> Squares = new List<Square>
        {
            new Square(0, 0),
            new Square(14, 1),
            new Square(10, 1),
            new Square(6, 1),
            new Square(2, 1),
            new Square(14, 5),
            new Square(10, 5),
            new Square(6, 5),
            new Square(2, 5),
            new Square(2, 3),
            new Square(6, 3),
            new Square(10, 3),
            new Square(14, 3),
            new Square(18, 3),
            new Square(22, 3),
            new Square(26, 3),
            new Square(30, 3),
            new Square(30, 1),
            new Square(26, 1),
            new Square(30, 5),
            new Square(26, 5),
            new Square(0, 0)
        };
        public static Dictionary<Coordinate, Square> CoordToSquare = new Dictionary<Coordinate, Square>
        {
            { Coordinate.Off, Squares[0] },
            { Coordinate.A1, Squares[1] },
            { Coordinate.A2, Squares[2] },
            { Coordinate.A3, Squares[3] },
            { Coordinate.A4, Squares[4] },
            { Coordinate.B1, Squares[5] },
            { Coordinate.B2, Squares[6] },
            { Coordinate.B3, Squares[7] },
            { Coordinate.B4, Squares[8] },
            { Coordinate.C1, Squares[9] },
            { Coordinate.C2, Squares[10] },
            { Coordinate.C3, Squares[11] },
            { Coordinate.C4, Squares[12] },
            { Coordinate.C5, Squares[13] },
            { Coordinate.C6, Squares[14] },
            { Coordinate.C7, Squares[15] },
            { Coordinate.C8, Squares[16] },
            { Coordinate.A5, Squares[17] },
            { Coordinate.A6, Squares[18] },
            { Coordinate.B5, Squares[19] },
            { Coordinate.B6, Squares[20] },
            { Coordinate.Home, Squares[21] }
        };
        public static List<Square> Player1SquareSequence = new List<Square>
        {
            CoordToSquare[Coordinate.Off],
            CoordToSquare[Coordinate.A1],
            CoordToSquare[Coordinate.A2],
            CoordToSquare[Coordinate.A3],
            CoordToSquare[Coordinate.A4],
            CoordToSquare[Coordinate.C1],
            CoordToSquare[Coordinate.C2],
            CoordToSquare[Coordinate.C3],
            CoordToSquare[Coordinate.C4],
            CoordToSquare[Coordinate.C5],
            CoordToSquare[Coordinate.C6],
            CoordToSquare[Coordinate.C7],
            CoordToSquare[Coordinate.C8],
            CoordToSquare[Coordinate.A5],
            CoordToSquare[Coordinate.A6],
            CoordToSquare[Coordinate.Home]
        };
        public static List<Square> Player2SquareSequence = new List<Square>
        {
            CoordToSquare[Coordinate.Off],
            CoordToSquare[Coordinate.B1],
            CoordToSquare[Coordinate.B2],
            CoordToSquare[Coordinate.B3],
            CoordToSquare[Coordinate.B4],
            CoordToSquare[Coordinate.C1],
            CoordToSquare[Coordinate.C2],
            CoordToSquare[Coordinate.C3],
            CoordToSquare[Coordinate.C4],
            CoordToSquare[Coordinate.C5],
            CoordToSquare[Coordinate.C6],
            CoordToSquare[Coordinate.C7],
            CoordToSquare[Coordinate.C8],
            CoordToSquare[Coordinate.B5],
            CoordToSquare[Coordinate.B6],
            CoordToSquare[Coordinate.Home]
        };

        public static int RollDice()
        {
            _die1Value = _rng.Next(0, 2) == 0 ? false : true;
            _die2Value = _rng.Next(0, 2) == 0 ? false : true;
            _die3Value = _rng.Next(0, 2) == 0 ? false : true;
            _die4Value = _rng.Next(0, 2) == 0 ? false : true;
            var roll = 0;
            if (_die1Value) roll++;
            if (_die2Value) roll++;
            if (_die3Value) roll++;
            if (_die4Value) roll++;
            _diceCount = roll;
            return roll;
        }

        public static void DrawBoardInfo()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write(BoardInfoLayout);

            // Player piece stats
            Console.SetCursorPosition(10, 7);
            Console.Write(Game.Player1.CountOffPieces());
            Console.SetCursorPosition(12, 7);
            Console.Write(Game.Player1.CountHomePieces());
            Console.SetCursorPosition(10, 9);
            Console.Write(Game.Player2.CountOffPieces());
            Console.SetCursorPosition(12, 9);
            Console.Write(Game.Player2.CountHomePieces());

            // Dice visual
            Console.SetCursorPosition(26, 7);
            Console.Write($"{(_die1Value ? "●" : "○")}{(_die2Value ? "●" : "○")}{(_die3Value ? "●" : "○")}{(_die4Value ? "●" : "○")} {_diceCount}");

            // Message + instruction text
            Console.SetCursorPosition(0, 10);
            Console.WriteLine(Message);
            Console.Write(Instructions);

            // Pieces on board
            foreach (var piece in Game.Player1.Pieces)
            {
                var square = piece.Square;
                Console.SetCursorPosition(square.Left, square.Top);
                Console.BackgroundColor = piece.Player.Color;
                if (IsSqaureRosette(square))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            foreach (var piece in Game.Player2.Pieces)
            {
                var square = piece.Square;
                Console.SetCursorPosition(square.Left, square.Top);
                Console.BackgroundColor = piece.Player.Color;
                if (IsSqaureRosette(square))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.ReadLine();
        }

        private static bool IsSqaureRosette(Square square)
        {
            if (square == CoordToSquare[Coordinate.A4] || 
                square == CoordToSquare[Coordinate.B4] || 
                square == CoordToSquare[Coordinate.C4] || 
                square == CoordToSquare[Coordinate.A6] || 
                square == CoordToSquare[Coordinate.B6])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static void Refresh()
        //{
        //    Console.Clear();
        //    DrawBoard();

        //    foreach (var piece in Game.Player1.Pieces)
        //    {
        //        piece.RefreshDraw();
        //    }
        //    Console.SetCursorPosition(10, 7);
        //    Console.Write(Game.Player1.CountOffPieces());
        //    Console.SetCursorPosition(12, 7);
        //    Console.Write(Game.Player1.CountHomePieces());

        //    foreach (var piece in Game.Player2.Pieces)
        //    {
        //        piece.RefreshDraw();
        //    }
        //    Console.SetCursorPosition(31, 7);
        //    Console.Write(Game.Player2.CountOffPieces());
        //    Console.SetCursorPosition(33, 7);
        //    Console.Write(Game.Player2.CountHomePieces());

        //    Console.WriteLine();
        //}

        //public static void DrawBoard()
        //{
        //    Console.WriteLine(BoardLayout);
        //    var rosettes = new List<Square>
        //    {
        //        CoordToSquare[Coordinate.A4],
        //        CoordToSquare[Coordinate.B4],
        //        CoordToSquare[Coordinate.C4],
        //        CoordToSquare[Coordinate.A6],
        //        CoordToSquare[Coordinate.B6]
        //    };
        //    Console.BackgroundColor = ConsoleColor.Magenta;
        //    foreach (var square in rosettes)
        //    {
        //        Console.SetCursorPosition(square.Left - 1, square.Top);
        //        Console.Write(" * ");
        //    }
        //    Console.BackgroundColor = ConsoleColor.Black;
        //    Console.SetCursorPosition(1, 6);
        //    Console.WriteLine();
        //    Console.WriteLine("Player 1: 7|0        Player 2: 7|0");
        //    /*
        //     * P1 Offs:  (10, 7)
        //     * P1 Homes: (12, 7)
        //     * P2 Offs:  (31, 7)
        //     * P2 Homes: (33, 7)
        //    */
        //}
    }
}
