using System;
using Perudo.Properties;

namespace Perudo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PerudoEngine perudoEngine = new PerudoEngine();
            

            while (true)
            {
                perudoEngine.Execute();
            }
 
        }
    }
}