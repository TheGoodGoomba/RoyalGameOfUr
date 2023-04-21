using System.Net;

namespace RoyalGameOfUr
{
    public class Program
    {
        public static string BasePath = AppDomain.CurrentDomain.BaseDirectory;

        static void Main(string[] args)
        {
            Board.DrawBoard();
            Console.ReadLine();
            Game.Play();

            //Console.WriteLine(Dice.Roll());

            //Player1.Pieces[0].Move(Coordinate.A1);
            //Console.ReadLine();
            //Player2.Pieces[0].Move(Coordinate.A3);
            //Console.ReadLine();
        }
    }
}