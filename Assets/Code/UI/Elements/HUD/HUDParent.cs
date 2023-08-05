using Code.Infrastructure.Factory;
using Code.Logic.GameWorld;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements.HUD
{
	public class HUDParent : MonoBehaviour, IGameWorldPart
	{
		private IGameFactory _gameFactory;

		[Inject]
		private void Construct(IGameFactory gameFactory)
		{
			_gameFactory = gameFactory;
		}

		public void Initialize()
		{
			_gameFactory.CreateHud(transform);
		}
	}
}