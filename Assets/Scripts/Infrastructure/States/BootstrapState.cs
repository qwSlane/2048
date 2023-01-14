namespace Infrastructure.States {

    public class BootstrapState : IState {

        private const string Initial = "Initial";

        private GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        
        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader) {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() {
            _gameStateMachine.Enter<LoadLevelState, string>("Game");
        }

        public void Exit() {
            
        }

    }

}