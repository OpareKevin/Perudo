using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Perudo.Properties;

namespace Perudo
{
    public class PerudoEngine
    {
        private  BoardMonitor _monitor;
        private State _state;

        private int _round = 0;

        private Bet _currentBet;

        private Queue<IPlayer> _players = new Queue<IPlayer>();
        
        private Queue<PlayerController> _playerControllers;

        private PlayerController _currentPlayer;
        public PerudoEngine()
        {
           Queue<IPlayer> _players = new Queue<IPlayer>();
           
            Console.WriteLine("Home");
            Console.WriteLine("How many Players : ");

            var input =Convert.ToInt32(Console.ReadLine()) ;

            for (int i = 0; i < input; i++)
            {
                var human = new Human((ushort)(i + 1));
                _players.Enqueue(human);
                Console.Write(human);
                Console.WriteLine();
                Thread.Sleep(200);
            }
            
            _monitor = new BoardMonitor(_players);

            _playerControllers = new Queue<PlayerController>();

            foreach (var player in _players)
            {
                _playerControllers.Enqueue(new PlayerController(player));
            }

            _currentPlayer = _playerControllers.Peek();

            _state = State.StartRound;
        }

        private void MakeBet()
        {
            Console.WriteLine($"Player : {_currentPlayer.Player}: Your turn");
            Console.WriteLine("What is your Bet ? ");
            int[] input = Console.ReadLine()
                ?.Split(new Char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(item => int.Parse(item))
                .ToArray();
                    
            _currentBet = new Bet(input[0], input[1], _monitor);
            _currentPlayer.Bid(_currentBet);

            _state = State.PlayRound;
        }

        private void NextPlayer()
        {
            var tempPlayer = _playerControllers.Dequeue();
            _playerControllers.Enqueue(tempPlayer);
            _currentPlayer = _playerControllers.Peek();
            Console.WriteLine($"{_currentPlayer.Player}'s turn to place a bet");
        }


        public void Execute()
        {
            switch (_state)
            {
                case State.StartRound:
                    foreach (var player in _playerControllers)
                    {
                      player.Player.RollDice();
                    }
                    MakeBet();
                    _state = State.PlayRound;
                    
                    break;
                case State.PlayRound:
                    
                    Console.WriteLine($"Current bet: {_currentBet.Quantity.ToString()} {_currentBet.FaceValue} ' s ");
                    Console.WriteLine("Call Bullshit[0] or Increase Bet[1]");

                    string input = Console.ReadLine();

                    if (input=="1")
                    {
                        NextPlayer();
                        MakeBet();

                        _state = State.PlayRound;
                    }
                    else
                    {
                        Console.WriteLine($"There are {_monitor.GetTotalOfFaceValue(_currentPlayer.Bet.FaceValue)} {_currentPlayer.Bet.FaceValue}' s in the game  ");

                        if (_monitor.BullShit(_currentPlayer.Bet))
                        {
                            if (_currentPlayer.Player.Peek().Count < 2)
                            {
                                Console.WriteLine($"{_currentPlayer.Player} is OUT!");
                                _currentPlayer.Player.RemoveDice();
                                _playerControllers.Dequeue();
                                _state = State.StartRound;
                            }
                            else
                            {
                                _currentPlayer.Player.RemoveDice();
                                _state = State.StartRound;
                            }
                            
                        }
                        else
                        {
                            NextPlayer();
                        }
                    }
                    break;
                case State.Finish:
                    Console.WriteLine($"{_playerControllers.Peek().Player} You won");
                    Console.Read();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_playerControllers.Count == 1)
            {
                _state = State.Finish;
            }
        }
        private enum State
        {
            StartRound,
            PlayRound,
            Finish
        }
    }

    
}