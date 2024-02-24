using Code.Data.Models.GameModel;
using Code.Logic;
using Code.Services.GameOverService;
using Code.UI.Elements.HPBar;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements.HUD
{
	public class HudBase : MonoBehaviour
	{
		[SerializeField] private HpBar hpBar;
		
		private IGameModel _gameModel;
		private IGameOverService _gameOverService;
		
		[Inject]
		private void Construct(IGameModel gameModel, IGameOverService gameOverService)
		{
			_gameModel = gameModel;
			_gameOverService = gameOverService;
		}

		private void Awake()
		{
			hpBar.Construct(_gameModel.Player.GetComponent<IHealth>());
		}

		private void OnEnable()
		{
			_gameOverService.ResultsReported += OnResultsReported;
		}

		private void OnDisable()
		{
			_gameOverService.ResultsReported -= OnResultsReported;			
		}

		private void OnResultsReported(GameResults results)
		{
			Destroy(gameObject);
		}
	}
}