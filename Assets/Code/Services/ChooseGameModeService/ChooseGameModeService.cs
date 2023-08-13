using System.Collections.Generic;
using Code.Logic.GameModes;

namespace Code.Services.ChooseGameModeService
{
	public class ChooseGameModeService : IChooseGameModeService
	{
		private Dictionary<GameModes, IGameMode> _gameModesMap = new Dictionary<GameModes, IGameMode>();

		private IGameMode _currentGameMode;
		private GameModes _currentGameModeType;
		
		public ChooseGameModeService(ArenaGameMode arenaGameMode, SurvivalGameMode survivalGameMode)
		{
			_gameModesMap[GameModes.Arena] = arenaGameMode;
			_gameModesMap[GameModes.Survival] = survivalGameMode;
		}
		
		public void ChooseGameMode(GameModes mode)
		{
			_currentGameModeType = mode;
			_currentGameMode = _gameModesMap[mode];
			_currentGameMode.StartGameMode();
		}

		public GameModes GetCurrentGameMode()
			=> _currentGameModeType;
	}
}