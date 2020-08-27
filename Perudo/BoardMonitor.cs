using System;
using System.Collections.Generic;
using System.Linq;

namespace Perudo
{
    public class BoardMonitor
    {
        private readonly Queue<IPlayer> _playerControllers;

        public BoardMonitor(Queue<IPlayer> playerControllers)
        {
            _playerControllers = playerControllers;
        }

        private int GetTotalOfFaceValue(DiceFaces diceface)
        {
            var i = 0;

            switch (diceface)
            {
                case DiceFaces.one:

                    foreach (var player in _playerControllers)
                    {
                        var playerDice = player.Peek();
                        foreach (var face in playerDice)
                            if (face.Face == DiceFaces.one)
                                i++;
                    }
                    break;
                
                default:
                    foreach (var player in _playerControllers)
                    {
                        var playerDice = player.Peek();
                        foreach (var face in playerDice)
                            if (face.Face == diceface || face.Face == DiceFaces.one)
                                i++;
                    }

                    break;
            }

            return i;
        }

        public bool BullShit(Bet bet)
        {
            var total = GetTotalOfFaceValue(bet.FaceValue);

            return bet.Quantity < total;
        }


        public int TotalDiceInPlay => _playerControllers.Sum(x => x.Peek().Count);
    }
}