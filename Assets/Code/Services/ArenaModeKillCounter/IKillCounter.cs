using System;

namespace Code.Services.ArenaModeKillCounter
{
    public interface IKillCounter
    {
        event Action<int> KillCountChanged;
        public int Kills { get; }
        void AddKill();
        void Reset();
    }
}