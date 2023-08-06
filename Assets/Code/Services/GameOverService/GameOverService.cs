﻿using System;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Code.Services.GameOverService
{
    public class GameOverService : IGameOverService
    {
        public event Action<GameResults> ResultsReported;

        private IGameStateMachine _gameStateMachine;

        public GameOverService(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void OverGameWithResult(GameResults result)
        {
            ResultsReported?.Invoke(result);
            Debug.Log("Game ended");
            _gameStateMachine.Enter<GameOverState, GameResults>(result);
        }
    }
}