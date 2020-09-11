using System;
using System.Collections.Generic;
using System.Linq;
using Perudo.Properties;

namespace Perudo
{
    public abstract class Player : IPlayer
    {
        private readonly ushort _id;
        private IPlayer _playerImplementation;

        public Player(ushort id)
        {
            Dice = new List<Die>();
            for (var i = 0; i < 5; i++) 
                Dice.Add(new Die());

            _id = id;
        }

        public void RollDice()
        {
            int numDie = Dice.Count;
            Dice.Clear();
            for (var i = 0; i < numDie; i++) Dice.Add(new Die());
        }

        private List<Die> Dice { get; }

        public List<Die> Peek()
        {
            return Dice;
        }

        public void RaiseBid()
        {
            Call = Call.IncreaseBid;
        }

        public void RemoveDice()
        {
            Dice.RemoveAt(0);
        }

        public Call Call { get; private set; }

        public ushort ID
        {
            get
            {
                if (_id < 1) throw new PlayerIDNotValidExpection();

                return _id;
            }
        }

        public void Dudo()
        {
            Call = Call.CallDudo;
        }

        public override string ToString()
        {
            string s = $"Player {ID} : ";

            foreach (var die in Dice)
            {
                s +=  (int)die.Face +" " ;
            }

            return s;
        }
    }


    public interface IPlayer
    {
        void RollDice();

        List<Die> Peek();

        void Dudo();

        void RaiseBid();

        void RemoveDice();

        Call Call { get; }
    }

    
}