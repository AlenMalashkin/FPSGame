using Code.Services.ArenaModeKillCounter;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements.HUD
{
    public class EnemiesRemainDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI killsText;

        private IKillCounter _killCounter;
            
        [Inject]
        private void Construct(IKillCounter killCounter)
        {
            _killCounter = killCounter;
        }

        private void OnEnable()
        {
            _killCounter.KillCountChanged += OnKillCountChanged;
        }

        private void Start()
        {
            killsText.text = 0 + "";
        }

        private void OnDisable()
        {
            _killCounter.KillCountChanged -= OnKillCountChanged;
        }

        private void OnKillCountChanged(int kills)
        {
            killsText.text = kills + "";
        }
    }
}