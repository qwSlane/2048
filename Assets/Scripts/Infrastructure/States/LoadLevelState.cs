using Infrastructure.Kernel;
using UnityEngine;

namespace Infrastructure.States {

    public class LoadLevelState : IPayloadState<string> {

        private readonly GameStateMachine _gameStateMachine;

        private readonly SceneLoader _sceneLoader;
        //   private readonly Curtain _curtain;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader) {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string payload) {
            //   _curtain.Show();
            // _sceneLoader.SendProgress += _curtain.UpdateLoadingBar;
            _sceneLoader.Load(payload, OnLoaded);
        }

        private void OnLoaded() {
            //    _curtain.Hide();
            //   _sceneLoader.SendProgress -= _curtain.UpdateLoadingBar;
        }

        public void Exit() {
        }

    }

}