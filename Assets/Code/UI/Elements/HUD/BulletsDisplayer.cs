using Code.Data.Models.GameModel;
using Code.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements.HUD
{
	public class BulletsDisplayer : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI bulletsText;

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

		private void OnEnable()
		{
			_playerReload.BulletsCountChanged += OnBulletsCountChanged;
		}

		private void OnDisable()
		{
			_playerReload.BulletsCountChanged -= OnBulletsCountChanged;
		}

		private void OnBulletsCountChanged(int bulletsInClip, int bulletsInBag)
		{
			bulletsText.text = bulletsInClip + " / " + bulletsInBag;
		}
	}
}