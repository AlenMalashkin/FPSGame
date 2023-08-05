using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
	public class GameRunner : MonoBehaviour
	{
		private GameBootstrapper.Factory _gameBootstrapperFactory;
		
		[Inject]
		private void Construct(GameBootstrapper.Factory gameBootstrapperFactory)
		{
			_gameBootstrapperFactory = gameBootstrapperFactory;
		}
		
		private void Awake()
		{
			GameBootstrapper gameBootstrapper = FindObjectOfType<GameBootstrapper>();

			if (gameBootstrapper != null)
				return;
			
			_gameBootstrapperFactory.Create();
		}
	}
}