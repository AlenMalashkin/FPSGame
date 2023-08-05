using Code.Infrastructure.Factory;
using Code.Logic.GameWorld;
using UnityEngine;
using Zenject;

namespace Code.Logic.Spawners
{
	public class PlayerSpawner : MonoBehaviour, IGameWorldPart
	{
		private IGameFactory _gameFactory;
		
		[Inject]
		private void Construct(IGameFactory gameFactory)
		{
			_gameFactory = gameFactory;
		}
		
		public void Initialize()
		{
			_gameFactory.CreatePlayer(transform);
		}
	}
}