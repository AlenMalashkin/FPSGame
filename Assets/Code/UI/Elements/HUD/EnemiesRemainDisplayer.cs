using System;
using Code.Services.ArenaModeKillCounter;
using Code.Services.GameOverService;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements.HUD
{
    public class EnemiesRemainDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI killsText;
        [SerializeField] private int neededEnemies;

        private IKillCounter _killCounter;
        private IGameOverService _gameOverService;
            
        [Inject]
        private void Construct(IKillCounter killCounter, IGameOverService gameOverService)
        {
            _killCounter = killCounter;
            _gameOverService = gameOverService;
        }

        private void OnEnable()
        {
            _killCounter.KillCountChanged += OnKillCountChanged;
        }

        private void Start()
        {
            killsText.text = 0 + "/" + neededEnemies;
        }

        private void OnDisable()
        {
            _killCounter.KillCountChanged -= OnKillCountChanged;
        }

        private void OnKillCountChanged(int kills)
        {
            killsText.text = kills + "/" + neededEnemies;

            if (kills >= neededEnemies)
            {
                _gameOverService.OverGameWithResult(GameResults.Win);
                _killCounter.Reset();
            }
        }
    }
}