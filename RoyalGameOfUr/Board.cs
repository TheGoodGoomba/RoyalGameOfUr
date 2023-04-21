﻿using System;
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

        public static List<Move> FindLegalMoves(Player player, int diceRoll)
        {
            var legalMoves = new List<Move>();
            var squareSequence = player == Game.Player1 ? Player1SquareSequence : Player2SquareSequence;
            foreach (var piece in player.Pieces)
            {
                var currentSquareIndex = squareSequence.IndexOf(piece.Square);
                var potentialSquare = squareSequence[currentSquareIndex + diceRoll];
                if (potentialSquare.Piece == null)
                {
                    var move = new Move(piece, potentialSquare);
                    legalMoves.Add(move);
                }
            }
            return legalMoves;
        }

        public static void DrawMoveablePieces(Player player, List<Move> legalMoves)
        {
            var drawableMoves = new List<Move>();
            foreach (var move in legalMoves)
            {
                if (move.Piece.Square != CoordToSquare[Coordinate.Off])
                {
                    drawableMoves.Add(move);
                }
            }
            var i = 1;
            foreach (var move in drawableMoves)
            {
                Console.SetCursorPosition(move.Destination.Left, move.Destination.Top);
                Console.BackgroundColor = player.Color;
                Console.Write(i);
                i++;
            }
        }

        public static void DrawBoard()
        {
            Console.WriteLine(BoardLayout);
            var rosettes = new List<Square>
            {
                CoordToSquare[Coordinate.A4],
                CoordToSquare[Coordinate.B4],
                CoordToSquare[Coordinate.C4],
                CoordToSquare[Coordinate.A6],
                CoordToSquare[Coordinate.B6]
            };
            Console.BackgroundColor = ConsoleColor.Magenta;
            foreach (var square in rosettes)
            {
                Console.SetCursorPosition(square.Left - 1, square.Top);
                Console.Write(" * ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 6);
            Console.WriteLine();
            Console.WriteLine("Player 1: 7|0        Player 2: 7|0");
            /*
             * P1 Offs:  (10, 7)
             * P1 Homes: (12, 7)
             * P2 Offs:  (31, 7)
             * P2 Homes: (33, 7)
            */
        }
    }
}
