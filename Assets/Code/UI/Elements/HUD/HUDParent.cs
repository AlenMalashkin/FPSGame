using System.Collections.Generic;
using Code.Infrastructure.Factory;
using Code.Logic.GameModes;
using Code.Logic.GameWorld;
using Code.Services.ChooseGameModeService;
using UnityEngine;
using YG;
using Zenject;

namespace Code.UI.Elements.HUD
{
	public class HUDParent : MonoBehaviour, IGameWorldPart
	{
		private Dictionary<GameModes, HUDType> _desktopHudTypesMap = new Dictionary<GameModes, HUDType>()
		{
			[GameModes.Arena] = HUDType.ArenaHUDDesctop,
			[GameModes.Survival] = HUDType.SurvivalHUDDesctop,
			[GameModes.Unknown] = HUDType.BaseHUDDesctop
		};
		
		private Dictionary<GameModes, HUDType> _mobileHudTypesMap = new Dictionary<GameModes, HUDType>()
		{
			[GameModes.Arena] = HUDType.ArenaHUDMobile,
			[GameModes.Survival] = HUDType.SurvivalHUDMobile,
			[GameModes.Unknown] = HUDType.BaseHUDDesctop
		};
		
		private IGameFactory _gameFactory;
		private IChooseGameModeService _gameModeService;

		[Inject]
		private void Construct(IGameFactory gameFactory, IChooseGameModeService gameModeService)
		{
			_gameFactory = gameFactory;
			_gameModeService = gameModeService;
		}

		public void Initialize()
		{
			_gameFactory.CreateHud(transform,
				YandexGame.EnvironmentData.isMobile
					? _mobileHudTypesMap[_gameModeService.GetCurrentGameMode()]
					: _desktopHudTypesMap[_gameModeService.GetCurrentGameMode()]);
		}
	}
}