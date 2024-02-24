using System;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Services.InputService;

namespace Code.Services.GameOverService
{
    public class GameOverService : IGameOverService
    {
        public event Action<GameResults> ResultsReported;

        private IGameStateMachine _gameStateMachine;
        private IInputService _inputService;

        public GameOverService(IGameStateMachine gameStateMachine, IInputService inputService)
        {
            _gameStateMachine = gameStateMachine;
            _inputService = inputService;
        }

        public void OverGameWithResult(GameResults result)
        {
            ResultsReported?.Invoke(result);
            _gameStateMachine.Enter<GameOverState, GameResults>(result);
            _inputService.Disable();
        }
    }
}