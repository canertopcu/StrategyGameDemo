using UnityEngine;

public enum GameState { Pause, Play }

public interface IGameManager
{
    GameState State { get; set; }
    PoolManager poolManager { get; set; }
}

public class GameManager : IGameManager
{
    public GameState _state = GameState.Pause;
    public GameState State
    {
        get => _state;

        set
        {
            if (value != _state)
            {
                _state = value;
                EventManager.Get<OnGameStateChanged>().Execute(value);
            }
        }

    }

    private PoolManager _poolManager;
    public PoolManager poolManager
    {
        get => _poolManager; set => _poolManager = value;
    }

}
