using Code.Data;
using UnityEngine;

namespace Code.Services.SurvivalModeTimerService
{
    public class SurvivalModeTimerService : ISurvivalModeTimerService
    {
        public float Time { get; private set; }
        private IProgressModel _progressModel;
        private bool _isTimeCounting;

        public SurvivalModeTimerService(IProgressModel progressModel)
        {
            _progressModel = progressModel;
        }
        
        public void StartCount()
            => _isTimeCounting = true;

        public void CountTime()
        {
            if (_isTimeCounting)
                Time += UnityEngine.Time.deltaTime;

            if (_progressModel.Progress.RecordTime < Time)
                _progressModel.Progress.RecordTime = Time;
        }

        public void StopCount()
            => _isTimeCounting = false;

        public void ResetTimer()
            => Time = 0f;

        public string FormatTime(float time)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            return $"{minutes:00} : {seconds:00}";
        }
    }
}