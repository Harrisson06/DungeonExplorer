using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This is the main function entry point for the application.
    internal class Program
    {
        static void Main()
        {
            Game game = new Game();
            game.Start();
        }
    }
}
