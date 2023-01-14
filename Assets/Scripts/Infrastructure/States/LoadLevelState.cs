using System;
using UnityEngine;

namespace Infrastructure.States {

    public class LoadLevelState : IPayloadState<string> {

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader) {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() {
          
        }

        public void Enter(string payLoad) {
            _sceneLoader.Load(payLoad, OnLoaded);
        }

        private void OnLoaded() {
            GameObject.FindWithTag("Field").GetComponent<GameField>().Initialize();
        }

        public void Exit() {
        }

    }

}