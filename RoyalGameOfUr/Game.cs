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
            Console.Write("Player 1's Turn. ENTER to roll");
            var diceRoll = Dice.Roll();
            Console.ReadLine();
            Console.WriteLine(diceRoll);

            //var legalMoves = Board.FindLegalMoves(player, diceRoll);
            //Board.DrawMoveablePieces(player, legalMoves);
            SelectMove(player, diceRoll);

            Console.ReadLine();
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
            var i = 1;
            foreach (var move in drawableMoves)
            {
                Console.SetCursorPosition(move.Destination.Left, move.Destination.Top);
                Console.BackgroundColor = player.Color;
                Console.Write(i);
                move.Identifier = i;
                i++;
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
