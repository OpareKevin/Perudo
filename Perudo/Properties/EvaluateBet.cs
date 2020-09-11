using System;

namespace Perudo.Properties
{
    public class EvaluateBet
    {
        private readonly Bet _actualDice;
        private readonly BoardMonitor _boardMonitor;
        private readonly Bet _bet;

        public EvaluateBet(BoardMonitor boardMonitor, Bet bet)
        {
            _boardMonitor = boardMonitor;
            _bet = bet;
        }

        public Result Evaluate()
        {
            if (_actualDice.FaceValue > _bet.FaceValue && _actualDice.Quantity>= _bet.Quantity)
            {
                throw new BetNotValidException();
            }

            int quantity = _boardMonitor.GetTotalOfFaceValue(_bet.FaceValue);
            if (quantity >= _bet.Quantity)
            {
                //The player was not lying! The caller gets penalized
                return Result.Correct;
            }

            return Result.Wrong;
        }
    }
}