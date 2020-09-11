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

        int _numberOfPlayers;
        public CreatePlayers()
        {
            Players = new Queue<IPlayer>();

            Console.WriteLine("Home");
            Console.WriteLine("How many Players : ");

            var input = Console.ReadLine();
            _numberOfPlayers = Convert.ToInt32(input);

            for (int i = 0; i < _numberOfPlayers; i++)
            {
                var human = new Human((ushort)(i + 1));
                Players.Enqueue(human);
                Console.Write(human);
                Console.WriteLine();
                Thread.Sleep(200);
            }

        }
   
    }
}