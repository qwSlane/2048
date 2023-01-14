using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure {

    public class Bootstrapper : MonoBehaviour, ICoroutineRunner {

        [SerializeField] private GameField field;
        private Game _game;

        private void Awake() {
            _game = new Game(field, this);
            _game._StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }

    }

}