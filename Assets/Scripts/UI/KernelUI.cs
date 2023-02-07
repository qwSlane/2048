using System.Collections;
using System.Collections.Generic;
using Infrastructure.Kernel;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class KernelUI : MonoBehaviour {

    private const string Level = "Game";

    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button playButton;
    private GameStateMachine _stateMachine;

    [Inject]
    private void Construct(GameStateMachine stateMachine) {
        _stateMachine = stateMachine;
        exitButton.onClick.AddListener(Exit);
        playButton.onClick.AddListener(Play);
    }

    private void Play() {
        _stateMachine.Enter<LoadLevelState,string>(Level);
    }

    private void Exit() {
        Application.Quit();
    }

}
