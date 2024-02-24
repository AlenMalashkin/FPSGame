using Audio;
using Code.Data;
using Code.Data.Models.EnemySpawnerModel;
using Code.Data.Models.GameModel;
using Code.Infrastructure;
using Code.Infrastructure.Factory;
using Code.Infrastructure.StateMachine;
using Code.Logic.GameModes;
using Code.Services.ArenaModeKillCounter;
using Code.Services.Bank;
using Code.Services.ChooseGameModeService;
using Code.Services.GameOverService;
using Code.Services.PauseService;
using Code.Services.SaveService;
using Code.Services.StaticDataService;
using Code.Services.SurvivalModeTimerService;
using Code.UI.Elements.HUD;
using Code.UI.Elements.LoadingCurtain;
using Code.UI.Factory;
using Code.UI.Services;
using Zenject;

namespace Code.CompositionRoot
{
	public class GameInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindGameBootstraperFactory();

			BindCoroutineRunner();

			BindSceneLoader();

			BindLoadingCurtain();

			BindAudioPlayer();

			BindPauseService();
			
			BindGameStateMachine();

			BindChooseGameModeService();

			BindGameOverService();

			BindPersistentProgressModel();

			BindGameModel();

			BindEnemySpawnerModel();

			BindSaveService();

			BindBank();

			BindStaticDataService();

			BindWindowService();

			BindInputControlls();
			
			BindUIFactory();
			
			BindGameFactory();

			BindKillCountService();

			BindSurvivalModeTimerService();
		}

		private void BindGameBootstraperFactory()
		{
			Container
				.BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
				.FromComponentInNewPrefabResource(InfrastructurePrefabPaths.GameBootstrapper);
		}

		private void BindCoroutineRunner()
		{
			Container
				.Bind<ICoroutineRunner>()
				.To<CoroutineRunner>()
				.FromComponentInNewPrefabResource(InfrastructurePrefabPaths.CoroutineRunner)
				.AsSingle();
		}

		private void BindSceneLoader()
		{
			Container
				.BindInterfacesAndSelfTo<SceneLoader>()
				.AsSingle();
		}

		private void BindLoadingCurtain()
		{
			Container
				.BindInterfacesAndSelfTo<LoadingCurtain>()
				.FromComponentInNewPrefabResource(InfrastructurePrefabPaths.LoadingCurtain)
				.AsSingle();
		}

		private void BindAudioPlayer()
		{
			Container
				.Bind<MusicPlayer>()
				.FromComponentInNewPrefabResource(InfrastructurePrefabPaths.AudioPlayer)
				.AsSingle();
		}

		private void BindGameStateMachine()
		{
			Container
				.Bind<IGameStateMachine>()
				.FromSubContainerResolve()
				.ByInstaller<GameStateMachineInstaller>()
				.AsSingle();
		}

		private void BindChooseGameModeService()
		{
			Container
				.Bind<IChooseGameModeService>()
				.FromSubContainerResolve()
				.ByInstaller<GameModeServiceInstaller>()
				.AsSingle();
		}

		private void BindPauseService()
		{
			Container
				.BindInterfacesAndSelfTo<PauseService>()
				.AsSingle();
		}

		private void BindGameOverService()
		{
			Container
				.BindInterfacesAndSelfTo<GameOverService>()
				.AsSingle();
		}

		private void BindPersistentProgressModel()
		{
			Container
				.BindInterfacesAndSelfTo<ProgressModel>()
				.AsSingle();
		}

		private void BindGameModel()
		{
			Container
				.BindInterfacesAndSelfTo<GameModel>()
				.AsSingle();
		}

		private void BindEnemySpawnerModel()
		{
			Container
				.BindInterfacesAndSelfTo<EnemySpawnersModel>()
				.AsSingle();
		}

		private void BindSaveService()
		{
			Container
				.BindInterfacesAndSelfTo<SaveService>()
				.AsSingle();
		}

		private void BindBank()
		{
			Container
				.BindInterfacesAndSelfTo<Bank>()
				.AsSingle();
		}

		private void BindStaticDataService()
		{
			Container
				.BindInterfacesAndSelfTo<StaticDataService>()
				.AsSingle();
		}

		private void BindWindowService()
		{
			Container
				.BindInterfacesAndSelfTo<WindowService>()
				.AsSingle();
		}

		private void BindInputControlls()
		{
			Container
				.Bind<InputControlls>()
				.FromInstance(new InputControlls())
				.AsSingle();
		}

		private void BindUIFactory()
		{
			Container
				.BindInterfacesAndSelfTo<UIFactory>()
				.FromSubContainerResolve()
				.ByInstaller<UIFactoryInstaller>()
				.AsSingle();
		}

		private void BindGameFactory()
		{
			Container
				.BindInterfacesAndSelfTo<GameFactory>()
				.FromSubContainerResolve()
				.ByInstaller<GameFactoryInstaller>()
				.AsSingle();
		}

		private void BindKillCountService()
		{
			Container
				.BindInterfacesAndSelfTo<KillCounter>()
				.AsSingle();
		}

		private void BindSurvivalModeTimerService()
		{
			Container
				.BindInterfacesAndSelfTo<SurvivalModeTimerService>()
				.AsSingle();
		}
	}
}