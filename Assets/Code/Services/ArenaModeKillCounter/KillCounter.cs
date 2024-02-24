using System;
using Code.Data;

namespace Code.Services.ArenaModeKillCounter
{
    public class KillCounter : IKillCounter
    {
        public event Action<int> KillCountChanged;

        private IProgressModel _progressModel;
        private int _kills;

        public int Kills => _kills;

        public KillCounter(IProgressModel progressModel)
        {
            _progressModel = progressModel;
        }

        public void AddKill()
        {
            _kills += 1;

            if (_progressModel.Progress.RecordKillCount < _kills)
                _progressModel.Progress.RecordKillCount = _kills;
            
            KillCountChanged?.Invoke(_kills);
        }

        public void Reset()
        {
            _kills = 0;
            KillCountChanged?.Invoke(_kills); 
        }
    }
}