using System;

namespace Code.Services.GameOverService
{
    public interface IGameOverService
    {
        event Action<GameResults> ResultsReported;
        void OverGameWithResult(GameResults result);
    }
}