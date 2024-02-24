using Code.Data.Models.GameModel;
using Code.Services.ArenaModeKillCounter;
using Code.Services.SurvivalModeTimerService;
using Code.UI.Elements.LoadingCurtain;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.StateMachine.States
{
    public class GameState : IPayloadedState<string>
    {
        private IGameStateMachine _gameStateMachine;
        private ISceneLoader _sceneLoader;
        private LoadingCurtain _loadingCurtain;
        private IGameModel _gameModel;
        private IKillCounter _killCounter;
        private ISurvivalModeTimerService _survivalModeTimerService;

        public GameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            LoadingCurtain loadingLoadingCurtain, IGameModel gameModel, IKillCounter killCounter,
            ISurvivalModeTimerService survivalModeTimerService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingLoadingCurtain;
            _gameModel = gameModel;
            _killCounter = killCounter;
            _survivalModeTimerService = survivalModeTimerService;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, OnLoad);
            _loadingCurtain.Show();
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Exit()
        {
            Cursor.lockState = CursorLockMode.None;
            _killCounter.Reset();
            _survivalModeTimerService.ResetTimer();
            _survivalModeTimerService.StopCount();
        }

        private void OnLoad()
        {
            _loadingCurtain.Hide();
            _gameModel.GameWorldInitializer.InitializeGameWorld();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameState>
        {
        }
    }
}