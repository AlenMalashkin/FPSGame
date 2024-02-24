using System;

namespace Code.Data.Models.Settings
{
    [Serializable]
    public class PlayerSettings
    {
        public float MusicVolume = 0.5f;
        public float SfxVolume = 0.5f;
        public float Sensitivity = 1f;
    }
}