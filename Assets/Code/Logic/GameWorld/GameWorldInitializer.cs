using Code.Data.Models.GameModel;
using Code.Infrastructure.Factory;
using Code.Logic.GameWorld;
using Code.Services.ChooseGameModeService;
using UnityEngine;
using Zenject;

public class GameWorldInitializer : MonoBehaviour
{
    private IGameFactory _gameFactory;
    private IGameModel _gameModel;
    private IChooseGameModeService _gameModeService;

    [Inject]
    private void Construct(IGameFactory gameFactory, IGameModel gameModel, 
        IChooseGameModeService gameModeService)
    {
        _gameFactory = gameFactory;
        _gameModel = gameModel;
        _gameModeService = gameModeService;
    }
    
    private void Awake()
    {
        _gameModel.GameWorldInitializer = this;
    }

    public void InitializeGameWorld()
    {
        IGameWorldPart gameWorldPart = _gameFactory.CreateLevel(_gameModeService.GetCurrentGameMode(), transform)
            .GetComponent<IGameWorldPart>();
        
        gameWorldPart.Initialize();
    }
}
