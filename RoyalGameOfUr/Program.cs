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
            Console.ReadLine();
            Console.SetCursorPosition(0, 13);
        }
    }
}