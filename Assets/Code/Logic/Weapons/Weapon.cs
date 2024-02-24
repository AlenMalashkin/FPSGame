using Code.Data;
using Plugins.Audio.Core;
using UnityEngine;
using Zenject;

namespace Code.Logic.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private ParticleSystem shootParticles;
        [SerializeField] private SourceAudio sourceAudio;

        private IProgressModel _progress;
        
        [Inject]
        private void Construct(IProgressModel progress)
        {
            _progress = progress;
        }
        
        public void NotifyShoot()
        {
            shootParticles.Play();
            sourceAudio.Volume = _progress.Progress.Settings.SfxVolume;
            sourceAudio.PlayOneShot("Shoot");
        }
    }
}