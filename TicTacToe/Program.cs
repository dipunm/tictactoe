using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.System;
using TicTacToe.TicTacToe;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var engine = new TicTacToeEngine();
            var system = new ConsoleSystem();
            do
            {
                system.Reset();
                engine.PlayGame(system);
            } while (ShouldLoop());
        }

        private static bool ShouldLoop()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Want to play again? (y/n)");
                var yesno = Console.ReadLine().Trim();

                var yes = String.Compare(yesno, "y", StringComparison.InvariantCultureIgnoreCase) == 0;
                var no = String.Compare(yesno, "n", StringComparison.InvariantCultureIgnoreCase) == 0;

                if (no)
                {
                    return false;
                }

                if (yes)
                {
                    return true;
                }
            } while (true);
        }
    }
}
