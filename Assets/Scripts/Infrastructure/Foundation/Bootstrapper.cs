using Infrastructure.States;
using UnityEngine;

namespace Infrastructure.Foundation {

    public class Bootstrapper : MonoBehaviour, ICoroutineRunner {
        
        private Game _game;

        private void Awake() {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }

    }

}