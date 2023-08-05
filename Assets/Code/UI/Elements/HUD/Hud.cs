using Code.Data.Models.GameModel;
using Code.Logic;
using Code.UI.Elements.HPBar;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements.HUD
{
	public class Hud : MonoBehaviour
	{
		[SerializeField] private HpBar hpBar;
		
		private IGameModel _gameModel;
		
		[Inject]
		private void Construct(IGameModel gameModel)
		{
			_gameModel = gameModel;
		}

		private void Awake()
		{
			hpBar.Construct(_gameModel.Player.GetComponent<IHealth>());
		}
	}
}