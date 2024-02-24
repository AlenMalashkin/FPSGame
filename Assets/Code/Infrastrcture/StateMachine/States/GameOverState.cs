using System;
using Code.Logic.GameModes;
using Code.Services.ArenaModeKillCounter;
using Code.Services.ChooseGameModeService;
using Code.Services.GameOverService;
using Code.Services.PauseService;
using Code.Services.SaveService;
using Code.Services.SurvivalModeTimerService;
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
        private IKillCounter _killCounter;
        private ISurvivalModeTimerService _survivalModeTimerService;
        private ISaveService _saveService;
        private IChooseGameModeService _gameModeService;

        public GameOverState(IGameStateMachine gameStateMachine, IUIFactory uiFactory,
            IPauseService pauseService, IKillCounter killCounter, ISurvivalModeTimerService survivalModeTimerService,
            ISaveService saveService, IChooseGameModeService gameModeService)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _pauseService = pauseService;
            _killCounter = killCounter;
            _survivalModeTimerService = survivalModeTimerService;
            _saveService = saveService;
            _gameModeService = gameModeService;
        }
        
        public void Enter(GameResults payload)
        {
            GameOverByGameMode();
            
            if (payload == GameResults.Lose)
                _uiFactory.CreateWindow(WindowType.Lose);
            else if (payload == GameResults.Win)
                _uiFactory.CreateWindow(WindowType.Win);

            _pauseService.Pause(PauseType.PauseTimeScaleOnly);
        }

        public void Exit()
        {
            _pauseService.Unpause(PauseType.PauseTimeScaleOnly);
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, GameOverState>
        {
        }

        private void GameOverByGameMode()
        {
            switch (_gameModeService.GetCurrentGameMode())
            {
                case GameModes.Arena:
                    _saveService.Save();
                    _killCounter.Reset();
                    break;
                case GameModes.Survival:
                    _survivalModeTimerService.StopCount();
                    _survivalModeTimerService.ResetTimer();
                    _saveService.Save();
                    break;
                case GameModes.Unknown:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}