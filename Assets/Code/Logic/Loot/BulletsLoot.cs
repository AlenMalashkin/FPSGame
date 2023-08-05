using Code.Data.Models.GameModel;
using Code.Player;
using Zenject;

namespace Code.Logic.Loot
{
	public class BulletsLoot : Loot
	{
		private IGameModel _gameModel;
		private PlayerReload _playerReload;
		
		[Inject]
		private void Construct(IGameModel gameModel)
		{
			_gameModel = gameModel;
		}

		private void Awake()
		{
			_playerReload = _gameModel.Player.GetComponent<PlayerReload>();
		}

		public override void Collect()
		{
			_playerReload.CollectBullets();
			Destroy(gameObject);
		}
	}
}