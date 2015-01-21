using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.ExtensionMethods
{
    public static class ConsoleHelper
    {
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
