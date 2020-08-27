using System;
using Perudo.Properties;

namespace Perudo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PerudoEngine perudoEngine = new PerudoEngine();

            
            
            Console.WriteLine("Select x or X to exit\n");
            //string s = Convert.ToString(Console.ReadLine());

            perudoEngine.Execute();
            
            
            
        }
    }
}