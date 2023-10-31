using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
namespace CoolConsoleApp2
{

    internal class Program
    {
     
        static void Main(string[] args)
        {
            Cakes cakes = new Cakes();
            cakes.Menu();
        }
    }
}