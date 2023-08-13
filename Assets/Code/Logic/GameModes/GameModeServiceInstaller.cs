using Code.Services.ChooseGameModeService;
using Zenject;

namespace Code.Logic.GameModes
{
	public class GameModeServiceInstaller : Installer<GameModeServiceInstaller>
	{
		public override void InstallBindings()
		{
			Container
				.Bind<ArenaGameMode>()
				.AsSingle();

			Container
				.Bind<SurvivalGameMode>()
				.AsSingle();

			Container
				.BindInterfacesAndSelfTo<ChooseGameModeService>()
				.AsSingle();
		}
	}
}