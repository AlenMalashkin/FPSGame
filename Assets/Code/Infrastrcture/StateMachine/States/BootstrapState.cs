using Code.Assets;
using Code.Services.StaticDataService;
using Code.UI.Elements.LoadingCurtain;
using Zenject;

namespace Code.Infrastructure.StateMachine.States
{
	public class BootstrapState : IState
	{
		private const string SceneName = "Bootstrap";
		
		private IGameStateMachine _gameStateMachine;
		private SceneLoader _sceneLoader;
		private LoadingCurtain _loadingCurtain;
		private IStaticDataService _staticDataService;
			
		public BootstrapState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader,
			LoadingCurtain loadingCurtain, IStaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
			_loadingCurtain = loadingCurtain;
			_staticDataService = staticDataService;
		}

		public void Enter()
		{
			_sceneLoader.Load(SceneName, OnLoaded);
			_staticDataService.Load();
			_loadingCurtain.Show();
		}

		public void Exit()
		{
		}

		private void OnLoaded()
			=> _gameStateMachine.Enter<LoadProgressState>();

		public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
		{
		}
	}
}