using System;
using Code.Data;
using Code.Infrastructure;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Logic.GameModes;
using Code.Services.ChooseGameModeService;
using Code.Services.SurvivalModeTimerService;
using Code.UI.Elements.LoadingCurtain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows.GameOverWindow
{
    public class GameOverWindow : WindowBase
    {
        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI recordText;

        private IGameStateMachine _gameStateMachine;
        private LoadingCurtain _curtain;
        private IChooseGameModeService _gameModeService;
        private IProgressModel _progressModel;
        private ISurvivalModeTimerService _survivalModeTimerService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, LoadingCurtain curtain, IChooseGameModeService gameModeService, IProgressModel progressModel, ISurvivalModeTimerService survivalModeTimerService)
        {
            _gameStateMachine = gameStateMachine;
            _curtain = curtain;
            _gameModeService = gameModeService;
            _progressModel = progressModel;
            _survivalModeTimerService = survivalModeTimerService;
        }

        private void OnEnable()
        {
            backButton.onClick.AddListener(Back);
        }

        private void OnDisable()
        {
            backButton.onClick.RemoveListener(Back);
        }

        private void Start()
        {
            if (_gameModeService.GetCurrentGameMode() == GameModes.Arena)
                recordText.text = "Рекорд: " + _progressModel.Progress.RecordKillCount;

            if (_gameModeService.GetCurrentGameMode() == GameModes.Survival)
                recordText.text = "Рекорд: " + _survivalModeTimerService.FormatTime(_progressModel.Progress.RecordTime);
        }

        private void Back()
        {
            _curtain.Show();
            _gameStateMachine.Enter<MenuState>();
        }
    }
}