using Code.Data.Models.GameModel;
using Code.Logic.GameWorld;
using UnityEngine;
using Zenject;

public class GameWorldInitializer : MonoBehaviour
{
    [SerializeField] private GameObject[] gameWorldParts;

    private IGameModel _gameModel;
    
    [Inject]
    private void Construct(IGameModel gameModel)
    {
        _gameModel = gameModel;
    }
    
    private void Awake()
    {
        _gameModel.GameWorldInitializer = this;
    }

    public void InitializeGameWorld()
    {
        foreach (var gameWorldPart in gameWorldParts)
        {
            gameWorldPart.GetComponent<IGameWorldPart>().Initialize();
        }
    }
}
