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

            Console.ReadLine();
        }

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
