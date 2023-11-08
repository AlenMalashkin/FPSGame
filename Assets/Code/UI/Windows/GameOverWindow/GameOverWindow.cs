using Code.Infrastructure;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.UI.Elements.LoadingCurtain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows.GameOverWindow
{
    public class GameOverWindow : WindowBase
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private Button backButton;

        [Header("Params")]
        [SerializeField] private string result;
        [SerializeField] private Color textColor;

        private IGameStateMachine _gameStateMachine;
        private LoadingCurtain _curtain;
        private SceneLoader _sceneLoader;
        
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }
        
        private void Awake()
        {
            resultText.text = result;
            resultText.color = textColor;
        }

        private void OnEnable()
        {
            backButton.onClick.AddListener(Back);
        }

        private void OnDisable()
        {
            backButton.onClick.RemoveListener(Back);
        }

        private void Back()
        {
            _curtain.Show();
            _gameStateMachine.Enter<MenuState>();
        }
    }
}