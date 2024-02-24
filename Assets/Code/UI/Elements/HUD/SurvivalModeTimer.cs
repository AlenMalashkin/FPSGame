using Code.Services.SurvivalModeTimerService;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements.HUD
{
    public class SurvivalModeTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        private ISurvivalModeTimerService _survivalModeTimerService;
        private float _seconds;

        [Inject]
        private void Construct(ISurvivalModeTimerService survivalModeTimerService)
        {
            _survivalModeTimerService = survivalModeTimerService;
        }

        private void Start()
        {
            _survivalModeTimerService.StartCount();
        }

        private void Update()
        {
            _survivalModeTimerService.CountTime();
            ChangeTimerValue(_survivalModeTimerService.Time);
        }

        private void ChangeTimerValue(float time)
        {
            timerText.text = _survivalModeTimerService.FormatTime(time);
        }
    }
}