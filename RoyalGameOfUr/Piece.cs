using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUr
{
    public class Piece
    {
        public Piece(Coordinate pos, Player player)
        {
            Position = pos;
            Player = player;
        }

        public Coordinate Position { get; set; }
        public Player Player { get; set; }

        public void Move(Coordinate newPosition)
        {
            Square oldSquare;
            if (Position == Coordinate.Off)
            {
                oldSquare = null;
            }
            else
            {
                oldSquare = Board.Squares.Find(x => x.Coordinates == Position);
            }
            var newSquare = Board.Squares.Find(x => x.Coordinates == newPosition);
            Console.SetCursorPosition(newSquare.Left, newSquare.Top);
            Console.BackgroundColor = Player.Color;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 5);
            Position = newPosition;
            if (oldSquare != null)
            {
                oldSquare.HasPiece = false;
            }
            newSquare.HasPiece = true;
        }

        public bool CanMove(int diceRoll, Player player)
        {
            List<Coordinate> squareSequence = new List<Coordinate>();
            if (player == Game.Player1)
            {
                squareSequence = Board.Player1SquareSequence;
            }
            else if (player == Game.Player2)
            {
                squareSequence = Board.Player2SquareSequence;
            }

            var sequenceId = squareSequence.IndexOf(Position);
            var potentialSquareCoordinates = squareSequence[sequenceId + diceRoll];
            var potentialSquare = Board.Squares.Find(x => x.Coordinates == potentialSquareCoordinates);
            if (!potentialSquare.HasPiece)
            {
                return true;
            }
            else
            {
                //find the piece (p1 or p2) that is on that square.
                //if it is the other player's then we can still move UNLESS it is on C4.


                return false;
            }
        }
    }
}
