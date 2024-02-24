namespace Code.Services.SurvivalModeTimerService
{
    public interface ISurvivalModeTimerService
    {
        float Time { get; }
        void StartCount();
        void CountTime();
        void StopCount();
        void ResetTimer();
        string FormatTime(float time);
    }
}