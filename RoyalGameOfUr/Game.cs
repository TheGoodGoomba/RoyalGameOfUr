using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void Turn(Player player)
        {
            Console.Write("Player 1's Turn. ENTER to roll:");
            var diceRoll = Dice.Roll();
            Console.ReadLine();
            Console.WriteLine(diceRoll);

            // 1. Find out the types of moves you can make (Place or Move)
            // 2. Options for each.

            //var avaliableMoveTypes = GetAvaliableMoveTypes(player, diceRoll);

            Console.ReadLine();
        }

        //public static MoveType? GetAvaliableMoveTypes(Player player, int diceRoll)
        //{
        //    var canPlace = false;
        //    var canMove = false;

        //    // Check for placing
        //    if (player == Player1)
        //    {
        //        canPlace = Board.Player1EntranceSpotFree(diceRoll);
        //    }
        //    else if (player == Player2)
        //    {
        //        canPlace = Board.Player2EntranceSpotFree(diceRoll);
        //    }

        //    // Check for moving
        //    var piecesOnBoard = new List<Piece>();
        //    foreach (var piece in player.Pieces)
        //    {
        //        if (piece.Position != Coordinate.Off && piece.Position != Coordinate.Home)
        //        {
        //            piecesOnBoard.Add(piece);
        //        }
        //    }
        //    foreach (var piece in piecesOnBoard)
        //    {
        //        canMove = piece.CanMove(diceRoll, player);
        //    }

        //    if (canPlace && canMove)
        //    {
        //        return MoveType.Either;
        //    }
        //    else if (canPlace && !canMove)
        //    {
        //        return MoveType.Place;
        //    }
        //    else if (canMove && !canPlace)
        //    {
        //        return MoveType.Move;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public static bool IsGameWon()
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
