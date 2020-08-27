using System;

namespace Perudo
{
    public class PlayerController
    {
        private Bet bet;
        
        public PlayerController(IPlayer player)
        {
            Player = player;
        }

        public IPlayer Player { get; }

        private void LooseDie()
        {
            Player.RemoveDice();
        }

        public Call Call()
        {
            return Player.Call;
        }

        public void Bid(Bet bet)
        {
            this.bet = bet;
        }

        public Bet Bet => bet;
    }

    public enum Call
    {
        CallDudo,
        IncreaseBid
    }
}