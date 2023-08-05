namespace Code.Services.InputService
{
	public interface IInputService
	{
		InputControlls InputControlls { get; }
		void Enable();
		void Disable();
	}
}