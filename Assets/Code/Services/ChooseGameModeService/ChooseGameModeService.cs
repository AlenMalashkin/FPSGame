using System.Collections.Generic;
using Code.Logic.GameModes;

namespace Code.Services.ChooseGameModeService
{
	public class ChooseGameModeService : IChooseGameModeService
	{
		private GameModes _currentGameModeType;
		
		public void ChooseGameMode(GameModes mode)
		{
			_currentGameModeType = mode;
		}

		public GameModes GetCurrentGameMode()
			=> _currentGameModeType;
	}
}