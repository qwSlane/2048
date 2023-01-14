using System;
using System.Collections.Generic;
using Infrastructure.States;
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