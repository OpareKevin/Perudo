using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Perudo.Properties
{
    public class CreatePlayers
    {
        public bool CreatedPlayers { get; private set; }
        public Queue<IPlayer> Players { get; }

        public CreatePlayers()
        {
            Players = new Queue<IPlayer>();
        }

       public void Execute()
        {
            Console.WriteLine("Home");
            Console.WriteLine("How many Players : ");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfPlayers; i++)
            {
                var human = new Human((ushort) (i + 1));
                Players.Enqueue(human);
                Console.Write(human);
                Console.WriteLine();
                Thread.Sleep(200);
            }

           

            

            CreatedPlayers = true;
        }
        
        
    }
}