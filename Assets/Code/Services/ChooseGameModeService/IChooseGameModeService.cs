using Code.Logic.GameModes;

namespace Code.Services.ChooseGameModeService
{
	public interface IChooseGameModeService
	{
		void ChooseGameMode(GameModes mode);
		GameModes GetCurrentGameMode();
	}
}