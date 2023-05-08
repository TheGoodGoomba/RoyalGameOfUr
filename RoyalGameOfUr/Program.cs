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

            string p1Name;
            string p2Name;
            while (true)
            {
                Console.Write("Player 1's Name: ");
                p1Name = Console.ReadLine();
                if (p1Name == "")
                {
                    Console.WriteLine("Name can't be blank.");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Player 2's Name: ");
                p2Name = Console.ReadLine();
                if (p2Name == "")
                {
                    Console.WriteLine("Name can't be blank.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Press ENTER to begin game.");
            Console.ReadLine();

            Game.Play(p1Name, p2Name);
            Console.ReadLine();
            Console.SetCursorPosition(0, 13);
        }
    }
}