using Infrastructure;
using UnityEngine;

public class Game {

    private GameField _field;
    public GameStateMachine _StateMachine;

    public Game(GameField field, ICoroutineRunner coroutineRunner) {
        _StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        _field = field;
        _field.Initialize();
    }

}