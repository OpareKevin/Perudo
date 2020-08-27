using System;

namespace Perudo.Properties
{
    public class EvaluateBet
    {
        private readonly Bet _actualDice;
        private readonly Bet _bet;

        public EvaluateBet(Bet currentBet, Bet bet)
        {
            _actualDice = currentBet;
            bet = bet;
        }

        public void Evaluate()
        {

            if (_actualDice.FaceValue > _bet.FaceValue && _actualDice.Quantity>= _bet.Quantity)
            {
                throw new BetNotValidException();
            }
            
        }
    }
}