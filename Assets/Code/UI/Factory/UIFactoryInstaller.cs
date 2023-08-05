using Zenject;

namespace Code.UI.Factory
{
	public class UIFactoryInstaller : Installer<UIFactoryInstaller>	
	{
		public override void InstallBindings()
		{
			Container
				.BindInterfacesAndSelfTo<UIFactory>()
				.AsSingle();
		}
	}
}