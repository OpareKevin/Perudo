using System;
using System.Collections.Generic;
using Perudo.Properties;

namespace Perudo
{
    public class PerudoEngine
    {
        private  PerudoManager _manager;
        private  BoardMonitor _monitor;
        private State _state;

        private int _round = 0;
        

        private CreatePlayers _createPlayers;

        public PerudoEngine()
        {
            _createPlayers = new CreatePlayers();

        }

        public void Execute()
        {
            switch (_state)
            {
                case State.StartGame:
                    if (_createPlayers.CreatedPlayers)
                    {
                        _monitor = new BoardMonitor(_createPlayers.Players);

                        var playerControllers = new Queue<PlayerController>();

                        foreach (var player in _createPlayers.Players)
                        {
                            playerControllers.Enqueue(new PlayerController(player));
                        }
                        
                        _manager = new PerudoManager(playerControllers);
                        _state = State.PlayRound;
                    }
                    else
                    {
                        _createPlayers.Execute();
                        _round = 1;
                    }
                    break;
                case State.PlayRound:
                    
                    _manager.StartRound(_round==1);
                    //_manager.NextRound();
                    break;
                case State.NextRound:
                    break;
                case State.Finish:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private enum State
        {
            StartGame,
            PlayRound,
            NextRound,
            Finish
        }
    }

    
}