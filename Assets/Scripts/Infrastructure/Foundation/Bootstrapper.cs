using System;
using Infrastructure.Kernel;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure.Foundation {

    public class Bootstrapper : MonoBehaviour {

        private GameStateMachine _stateMachine;

        [Inject]
        public void Initialize(GameStateMachine stateMachine) {
            _stateMachine = stateMachine;
            _stateMachine.Enter<BootstrapState>();
        }

    }

}