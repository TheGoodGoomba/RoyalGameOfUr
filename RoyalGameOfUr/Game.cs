using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Game
    {
        public static Player Player1 = new Player(ConsoleColor.Blue);
        public static Player Player2 = new Player(ConsoleColor.DarkYellow);

        public static void Play()
        {
            while (!IsGameWon())
            {
                Turn(Player1);
                if (IsGameWon())
                {
                    break;
                }
                Turn(Player2);
            }
        }

        static void Turn(Player player)
        {
            Console.Write($"Player {(player == Player1 ? "1" : "2")}'s Turn. ENTER to roll");
            var diceRoll = Board.RollDice();
            Console.ReadLine();
            Console.WriteLine(diceRoll);

            SelectMove(player, diceRoll);
        }

        static void SelectMove(Player player, int diceRoll)
        {
            var legalMoves = new List<Move>();
            var squareSequence = player == Player1 ? Board.Player1SquareSequence : Board.Player2SquareSequence;
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

            var drawableMoves = new List<Move>();
            foreach (var move in legalMoves)
            {
                if (move.Piece.Square != Board.CoordToSquare[Coordinate.Off])
                {
                    drawableMoves.Add(move);
                }
            }
            var consoleReturn = Console.GetCursorPosition();
            var i = 1;
            foreach (var move in drawableMoves)
            {
                Console.SetCursorPosition(move.Piece.Square.Left, move.Piece.Square.Top);
                Console.BackgroundColor = player.Color;
                Console.Write(i);
                move.Identifier = i;
                i++;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(consoleReturn.Left, consoleReturn.Top);

            while (true)
            {
                Console.WriteLine("Type number of piece to move OR 'P' to place a piece on the board.");
                Console.Write(">>> ");
                var response = Console.ReadLine();
                int responseInt;
                var parsed = int.TryParse(response, out responseInt);
                if (response.ToLower() == "p")
                {
                    var pieceToPlace = player.Pieces.First(x => x.Square == Board.CoordToSquare[Coordinate.Off]);
                    var squareToGo = squareSequence[diceRoll];
                    pieceToPlace.Move(squareToGo, " ");
                    Console.WriteLine("Move here? (y/n)");
                    Console.Write(">>> ");
                    var confirmMoveResponse = Console.ReadLine();
                    if (confirmMoveResponse.ToLower() == "y")
                    {
                        break;
                    }
                    pieceToPlace.Remove(false);
                }
                else if (parsed)
                {
                    var desiredMove = drawableMoves.Find(x => x.Identifier == responseInt);
                    var oldSquare = desiredMove.Piece.Square;
                    desiredMove.Piece.Move(desiredMove.Destination, $"{desiredMove.Identifier}");
                    Console.WriteLine("Move here? (y/n)");
                    Console.Write(">>> ");
                    var confirmMoveResponse = Console.ReadLine();
                    if (confirmMoveResponse.ToLower() == "y")
                    {
                        var finalSquare = desiredMove.Piece.Square;
                        var cursorReturn = Console.GetCursorPosition();
                        Console.SetCursorPosition(finalSquare.Left, finalSquare.Top);
                        Console.BackgroundColor = player.Color;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(cursorReturn.Left, cursorReturn.Top);
                        break;
                    }
                    desiredMove.Piece.Move(oldSquare, $"{desiredMove.Identifier}");
                }
            }

            //Board.Refresh();
        }

        static bool IsGameWon()
        {
            var player1PiecesLeft = 7;
            foreach (var piece in Player1.Pieces)
            {
                if (piece.Square == Board.CoordToSquare[Coordinate.Home])
                {
                    player1PiecesLeft--;
                }
            }
            var player2PiecesLeft = 7;
            foreach (var piece in Player2.Pieces)
            {
                if (piece.Square == Board.CoordToSquare[Coordinate.Home])
                {
                    player2PiecesLeft--;
                }
            }
            if (player1PiecesLeft == 0 || player2PiecesLeft == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
