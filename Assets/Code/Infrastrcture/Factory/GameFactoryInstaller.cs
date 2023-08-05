using Zenject;

namespace Code.Infrastructure.Factory
{
	public class GameFactoryInstaller : Installer<GameFactoryInstaller>
	{
		public override void InstallBindings()
		{
			Container
				.BindInterfacesAndSelfTo<GameFactory>()
				.AsSingle();
		}
	}
}