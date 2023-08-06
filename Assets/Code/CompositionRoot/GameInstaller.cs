using Code.Data;
using Code.Data.Models.GameModel;
using Code.Infrastructure;
using Code.Infrastructure.Factory;
using Code.Infrastructure.StateMachine;
using Code.Services.Bank;
using Code.Services.GameOverService;
using Code.Services.InputService;
using Code.Services.PauseService;
using Code.Services.SaveService;
using Code.Services.StaticDataService;
using Code.UI.Elements.LoadingCurtain;
using Code.UI.Factory;
using Code.UI.Services;
using Zenject;

namespace CompositionRoot
{
	public class GameInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindGameBootstraperFactory();

			BindCoroutineRunner();

			BindSceneLoader();

			BindLoadingCurtain();

			BindPauseService();

			BindGameStateMachine();
			
			BindGameOverService();

			BindPersistentProgressModel();
			
			BindGameModel();

			BindSaveService();

			BindBank();

			BindStaticDataService();
			
			BindInputService();
			
			BindWindowService();

			BindUIFactory();
			
			BindGameFactory();
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

		private void BindGameStateMachine()
		{
			Container
				.Bind<IGameStateMachine>()
				.FromSubContainerResolve()
				.ByInstaller<GameStateMachineInstaller>()
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
				.BindInterfacesAndSelfTo<PersistentProgressModel>()
				.AsSingle();
		}

		private void BindGameModel()
		{
			Container
				.BindInterfacesAndSelfTo<GameModel>()
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

		private void BindInputService()
		{
			Container
				.BindInterfacesAndSelfTo<InputService>()
				.AsSingle();
		}

		private void BindWindowService()
		{
			Container
				.BindInterfacesAndSelfTo<WindowService>()
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
	}
}