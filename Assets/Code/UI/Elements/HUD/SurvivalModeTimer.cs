using Code.Services.GameOverService;
using TMPro;
using UnityEngine;
using VavilichevGD.Utils.Timing;
using Zenject;

namespace Code.UI.Elements.HUD
{
    public class SurvivalModeTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private float timeToEndSurvivalMode;

        private SyncedTimer _timer;
        private IGameOverService _gameOverService;

        [Inject]
        private void Construct(IGameOverService gameOverService)
        {
            _gameOverService = gameOverService;
        }
        
        private void Awake()
        {
            _timer = new SyncedTimer(TimerType.OneSecTick);
        }

        private void OnEnable()
        {
            _timer.TimerFinished += OnTimerFinished;
            _timer.TimerValueChanged += OnTimerValueChanged;
        }

        private void Start()
        {
            _timer.Start(timeToEndSurvivalMode);
        }

        private void OnDisable()
        {
            _timer.TimerFinished -= OnTimerFinished;
            _timer.TimerValueChanged -= OnTimerValueChanged;
        }

        private void OnTimerValueChanged(float time, TimeChangingSource source)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            timerText.text = $"{minutes:00} : {seconds:00}";
        }

        private void OnTimerFinished()
        {
            _gameOverService.OverGameWithResult(GameResults.Win);
        }
    }
}