using System;

namespace Code.Services.ArenaModeKillCounter
{
    public interface IKillCounter
    {
        event Action<int> KillCountChanged;
        void AddKill();
        void Reset();
    }
}