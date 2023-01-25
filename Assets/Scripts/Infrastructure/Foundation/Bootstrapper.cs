using Infrastructure.Kernel;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure.Foundation {

    public class Bootstrapper : MonoBehaviour {

        [Inject]
        public void Initialize(GameStateMachine stateMachine) {
            stateMachine.Enter<BootstrapState>();
        }

    }

}