using Plugins.Audio.Core;
using UnityEngine;

namespace Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private SourceAudio sourceAudio;
        
        public void PlayLoopedAudio(string audioName)
        {
            sourceAudio.Play(audioName);
            sourceAudio.Loop = true;
        }

        public void StopPlay()
            => sourceAudio.Stop();

        public void ChangeVolume(float volume)
            => sourceAudio.Volume = volume;
    }
}