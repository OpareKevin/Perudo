using System;
using System.Collections.Generic;
using System.Linq;

namespace Perudo.Properties
{
    public class PerudoManager
    {
        private readonly BoardMonitor _boardMonitor;

        private Tuple<DiceFaces, int> Bet;
        //private JudgeBet _judgeBet;

        private PlayerController currentPlayer;
        private readonly Queue<PlayerController> m_players;

        private PlayerController nextPlayer;

        private int round = 1;

        public PerudoManager(Queue<PlayerController> playerConttollers)
        {
            m_players = playerConttollers;


            var playersIngame = new List<IPlayer>();
            foreach (var player in m_players) playersIngame.Add(player.Player);

            //_judgeBet = new JudgeBet(currentPlayer,nextPlayer);
        }


        private int TotalPlayers => m_players.Count();

        public void StartRound(bool isFirstRound)
        {
            if (isFirstRound)
            {
                currentPlayer = m_players.Peek();
                nextPlayer = ReturnNextPlayer();
            }
            else
            {
                NextRound();
            }

            foreach (var player in m_players) player.Player.RollDice();
        }

        private void CurrentPlayersTurn()
        {
            var totalPlayers = TotalPlayers;

            for (var i = 0; i < totalPlayers - 1; i++) currentPlayer = ReturnNextPlayer();
        }


        private void NextRound()
        {
            if (_boardMonitor.BullShit(currentPlayer.Bet))
            {
                nextPlayer.Player.RemoveDice();
                CurrentPlayersTurn();
                nextPlayer = ReturnNextPlayer();
            }
            else
            {
                currentPlayer.Player.RemoveDice();
            }

            // _judgeBet = new JudgeBet(currentPlayer,nextPlayer);
        }


        private PlayerController ReturnNextPlayer()
        {
            var tempPlayer = m_players.Dequeue();
            m_players.Enqueue(tempPlayer);
            return m_players.Peek();
        }


        public void ManageRound()
        {
            var currentPlayerBet = nextPlayer.Call();

            switch (currentPlayerBet)
            {
                case Call.CallDudo:
                    if (_boardMonitor.BullShit(currentPlayer.Bet))
                    {
                        if (currentPlayer.Player.Peek().Count < 1)
                        {
                            CurrentPlayersTurn();
                            m_players.Dequeue();
                            currentPlayer = ReturnNextPlayer();
                        }
                        else
                        {
                            currentPlayer.Player.RemoveDice();
                        }
                    }
                    break;
                case Call.IncreaseBid:
                      //  nextPlayer.Bid(bet);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}