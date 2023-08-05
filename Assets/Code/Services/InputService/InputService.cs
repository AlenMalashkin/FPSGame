namespace Code.Services.InputService
{
	public class InputService : IInputService
	{
		public InputControlls InputControlls { get; }

		public InputService()
		{
			InputControlls = new InputControlls();
		}

		public void Enable()
		{
			InputControlls.Enable();
		}

		public void Disable()
		{
			InputControlls.Disable();
		}
	}
}