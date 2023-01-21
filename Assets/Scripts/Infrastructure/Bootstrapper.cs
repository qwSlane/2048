using Infrastructure.States;
using Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure {

    public class Bootstrapper : MonoBehaviour, ICoroutineRunner {
        
        private Game _game;

        private void Awake() {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }

    }

}