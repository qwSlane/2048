using Infrastructure.Kernel;

namespace Infrastructure.States {

    public class BootstrapState : IState {

        private const string Initial = "Initial";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly Curtain _curtain;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader) {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() {
            _sceneLoader.Load(Initial, onLoaded: MenuEnter);
        }

        private void MenuEnter() {
            _gameStateMachine.Enter<LoadLevelState, string>("MainMenu");
        }

        public void Exit() {
        }

    }

}