using System;

namespace Code.Services.ArenaModeKillCounter
{
    public class KillCounter : IKillCounter
    {
        public event Action<int> KillCountChanged;

        private int _kills;
        
        public void AddKill()
        {
            _kills += 1;
            KillCountChanged?.Invoke(_kills);
        }

        public void Reset()
        {
            _kills = 0;
            KillCountChanged?.Invoke(_kills); 
        }
    }
}