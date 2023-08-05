using Code.Data.Models.GameModel;
using Code.Player;
using Zenject;

namespace Code.Logic.Loot
{
	public class HealthLoot : Loot
	{
		private IGameModel _gameModel;
		private PlayerHealth _playerHealth;
		
		[Inject]
		private void Construct(IGameModel gameModel)
		{
			_gameModel = gameModel;
		}

		private void Awake()
		{
			_playerHealth = _gameModel.Player.GetComponent<PlayerHealth>();
		}
		
		public override void Collect()
		{
			_playerHealth.CollectHealth();
			Destroy(gameObject);
		}
	}
}