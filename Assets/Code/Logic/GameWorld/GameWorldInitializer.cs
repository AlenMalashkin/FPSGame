using System;
using Audio;
using Code.Data.Models.GameModel;
using Code.Infrastructure.Factory;
using Code.Logic.GameModes;
using Code.Logic.GameWorld;
using Code.Services.ChooseGameModeService;
using UnityEngine;
using Zenject;

public class GameWorldInitializer : MonoBehaviour
{
    private IGameFactory _gameFactory;
    private IGameModel _gameModel;
    private IChooseGameModeService _gameModeService;
    private MusicPlayer _musicPlayer;

    [Inject]
    private void Construct(IGameFactory gameFactory, IGameModel gameModel, 
        IChooseGameModeService gameModeService, MusicPlayer musicPlayer)
    {
        _gameFactory = gameFactory;
        _gameModel = gameModel;
        _gameModeService = gameModeService;
        _musicPlayer = musicPlayer;
    }
    
    private void Awake()
    {
        _gameModel.GameWorldInitializer = this;
    }

    public void InitializeGameWorld()
    {
        switch (_gameModeService.GetCurrentGameMode())
        {
            case GameModes.Arena:
                _musicPlayer.PlayLoopedAudio("ArenaMusic");
                break;
            case GameModes.Survival:
                _musicPlayer.PlayLoopedAudio("SurvivalMusic");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        IGameWorldPart gameWorldPart = _gameFactory.CreateLevel(_gameModeService.GetCurrentGameMode(), transform)
            .GetComponent<IGameWorldPart>();
        
        gameWorldPart.Initialize();
    }
}
