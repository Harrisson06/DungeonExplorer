﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
