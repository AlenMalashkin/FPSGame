using Code.Services.GameOverService;
using Code.Services.PauseService;
using Code.UI.Elements.LoadingCurtain;
using Code.UI.Factory;
using Code.UI.Windows;
using Zenject;

namespace Code.Infrastructure.StateMachine.States
{
    public class GameOverState : IPayloadedState<GameResults>
    {
        private IGameStateMachine _gameStateMachine;
        private IUIFactory _uiFactory;
        private IPauseService _pauseService;
        
        public GameOverState(IGameStateMachine gameStateMachine, IUIFactory uiFactory,
            IPauseService pauseService)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _pauseService = pauseService;
        }
        
        public void Enter(GameResults payload)
        {
            if (payload == GameResults.Lose)
                _uiFactory.CreateGameOverWindow(WindowType.Lose);
            else if (payload == GameResults.Win)
                _uiFactory.CreateGameOverWindow(WindowType.Win);

            _pauseService.Pause();
        }

        public void Exit()
        {
            _pauseService.Unpause();
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, GameOverState>
        {
        }
    }
}