﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Game
    {
        public static Player Player1;
        public static Player Player2;

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

        public static void Play(string p1Name, string p2Name)
        {
            Player1 = new Player(p1Name, ConsoleColor.Blue, ConsoleColor.Gray);
            Player2 = new Player(p2Name, ConsoleColor.DarkYellow, ConsoleColor.Black);

            while (!IsGameWon())
            {
                Turn(Player1);
                if (IsGameWon())
                {
                    break;
                }
                Turn(Player2);
            }

            Board.SetMessage($"{(Player1.HasWon ? $"{Player1.Name}" : $"{Player2.Name}")} won the game!");
            Board.SetInstructions("Press ENTER to close.");
        }

        static void Turn(Player player)
        {
            while (true)
            {
                var repeatTurn = false;

                Board.SetMessage($"{player.Name}'s Turn.");
                Board.SetInstructions("Any key to roll.");
                Console.ReadKey(true);
                Board.RollDice();
                Board.SetMessage($"{player.Name} rolled a {Board.DiceValue}.");
                Board.SetInstructions("Type the letter of the piece to move.");
                var legalMoves = Board.ShowMoves(player);
                if (legalMoves.Count == 0)
                {
                    Board.SetMessage($"{player.Name} rolled a {Board.DiceValue}. No legal moves!");
                    Board.SetInstructions("Press ENTER to end turn.");
                    while (true)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    repeatTurn = SelectMove(legalMoves, player);
                }

                Board.ResetDice();

                if (!repeatTurn)
                {
                    break;
                }
            }
        }

        static bool SelectMove(List<Move> legalMoves, Player player)
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
                    if (Board.IsSquareRosette(desiredMove.Destination))
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
            if (player1PiecesLeft == 0)
            {
                Player1.HasWon = true;
                return true;
            }
            else if (player2PiecesLeft == 0)
            {
                Player2.HasWon = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
