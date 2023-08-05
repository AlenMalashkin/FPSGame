using Code.Infrastructure.StateMachine.States;
using Zenject;

namespace Code.Infrastructure.StateMachine
{
	public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
	{
		public override void InstallBindings()
		{
			Container
				.BindFactory<IGameStateMachine, BootstrapState, BootstrapState.Factory>();
			Container
				.BindFactory<IGameStateMachine, LoadProgressState, LoadProgressState.Factory>();
			Container
				.BindFactory<IGameStateMachine, MenuState, MenuState.Factory>();
			Container
				.BindFactory<IGameStateMachine, GameState, GameState.Factory>();

			Container
				.BindInterfacesAndSelfTo<GameStateMachine>()
				.AsSingle();
		}
	}
}