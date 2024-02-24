using Code.Services.ChooseGameModeService;
using Zenject;

namespace Code.Logic.GameModes
{
	public class GameModeServiceInstaller : Installer<GameModeServiceInstaller>
	{
		public override void InstallBindings()
		{
			Container
				.BindInterfacesAndSelfTo<ChooseGameModeService>()
				.AsSingle();
		}
	}
}