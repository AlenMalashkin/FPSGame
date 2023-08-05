using Code.Data.Models.GameModel;
using Code.UI.Elements.LoadingCurtain;
using Zenject;

namespace Code.Infrastructure.StateMachine.States
{
	public class GameState : IPayloadedState<string>
	{
		private IGameStateMachine _gameStateMachine;
		private ISceneLoader _sceneLoader;
		private LoadingCurtain _loadingCurtain;
		private IGameModel _gameModel;
		
		public GameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, 
			LoadingCurtain loadingLoadingCurtain, IGameModel gameModel)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
			_loadingCurtain = loadingLoadingCurtain;
			_gameModel = gameModel;
		}
		
		public void Enter(string payload)
		{
			_sceneLoader.Load(payload, OnLoad);
			_loadingCurtain.Show();
		}

		public void Exit()
		{
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