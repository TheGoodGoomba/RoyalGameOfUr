using System.Net;

namespace RoyalGameOfUr
{
    public class Program
    {
        public static string BasePath = AppDomain.CurrentDomain.BaseDirectory;
        public static Player Player1 = new Player(ConsoleColor.Blue);
        public static Player Player2 = new Player(ConsoleColor.DarkYellow);

        static void Main(string[] args)
        {
            Board.DrawBoard();
            Console.ReadLine();
            Player1.Pieces[0].Move(Coordinate.A1);
            Console.ReadLine();
            Player2.Pieces[0].Move(Coordinate.A3);
            Console.ReadLine();
        }
    }
}