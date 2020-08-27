using System;
using System.Threading;
using Perudo.Properties;

namespace Perudo
{
    public class Die
    {
        private int face;
        public Die()
        {
            Random rnd = new Random();

            lock (rnd)
            {
                face =  rnd.Next(1, 7);
                Thread.Sleep(10);
            }
            
        }

        public DiceFaces Face => (DiceFaces)face;

        public override string ToString()
        {
            return Face.ToString();
        }
    }

    public class Bet
    {

        public Bet(int quantity,int faceValue, BoardMonitor boardMonitor)
        {
            if (quantity > boardMonitor.TotalDiceInPlay || faceValue< 1 || faceValue>6 )
            {
                throw new BetNotValidException();
            }

            Quantity = quantity;
            FaceValue = (DiceFaces)faceValue;
        }

        public int Quantity { get; }

        public DiceFaces FaceValue { get; }
    }
}