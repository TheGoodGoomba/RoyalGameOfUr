using System.Net;
using System.Text;

namespace RoyalGameOfUr
{
    public class Program
    {
        public static string BasePath = AppDomain.CurrentDomain.BaseDirectory;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Board.DrawBoardInfo();
            Game.Play();

            //Console.WriteLine(Dice.Roll());

            //Player1.Pieces[0].Move(Coordinate.A1);
            //Console.ReadLine();
            //Player2.Pieces[0].Move(Coordinate.A3);
            //Console.ReadLine();
        }
    }
}