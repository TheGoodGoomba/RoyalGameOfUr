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
        public static Player Player1 = new Player(ConsoleColor.Blue, ConsoleColor.Gray);
        public static Player Player2 = new Player(ConsoleColor.DarkYellow, ConsoleColor.Black);

        static Dictionary<ConsoleKey, char> KeyToChar = new Dictionary<ConsoleKey, char>
        {
            { ConsoleKey.A, 'A' },
            { ConsoleKey.B, 'B' },
            { ConsoleKey.C, 'C' },
            { ConsoleKey.D, 'D' },
            { ConsoleKey.E, 'E' },
            { ConsoleKey.F, 'F' },
            { ConsoleKey.G, 'G' },
        };

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
            var currentPlayerStr = $"Player {(player == Player1 ? "1" : "2")}";

            Board.SetMessage($"{currentPlayerStr}'s Turn.");
            Board.SetInstructions("Any key to roll.");
            Console.ReadKey(true);
            Board.RollDice();
            Board.SetMessage($"{currentPlayerStr} rolled a {Board.DiceValue}.");
            Board.SetInstructions("Type the number of the piece to move.");
            var legalMoves = Board.ShowMoves(player);
            if (legalMoves.Count == 0)
            {
                Board.SetMessage($"{currentPlayerStr} rolled a {Board.DiceValue}. No legal moves!");
                Board.SetInstructions("Press ENTER to end turn.");
                while (true)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            else
            {
                SelectMove(legalMoves, player);
            }

            Board.ResetDice();
        }

        static void SelectMove(List<Move> legalMoves, Player player)
        {
            while (true)
            {
                char? pieceId;
                while (true)
                {
                    var key = Console.ReadKey(true);
                    try
                    {
                        pieceId = KeyToChar[key.Key];
                    }
                    catch (KeyNotFoundException)
                    {
                        pieceId = null;
                    }

                    if (pieceId != null)
                    {
                        break;
                    }
                }

                var desiredMove = legalMoves.FirstOrDefault(x => x.Identifier == pieceId);
                if (desiredMove != null)
                {
                    desiredMove.Piece.Move(desiredMove.Destination);
                    return;
                }
            }
        }

        //static int KeyToChar(ConsoleKey key)
        //{
        //    if (ConsoleKey.D1 <= key && key <= ConsoleKey.D7)
        //    {
        //        return ((int)key) - 48;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

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
