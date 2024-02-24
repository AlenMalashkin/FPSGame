namespace Code.Services.PauseService
{
    public interface IPauseService
    {
        bool Paused { get; }
        void Pause(PauseType type);
        void Unpause(PauseType type);
    }
}