using Entities;
using Services;
using UnityEngine;
using Zenject;

namespace Infrastructure.Kernel.Field {

    public class GameField : MonoBehaviour {

        private CellMover _cellMover;
        private GameData _gameData;
        private TileSpawner _tileSpawner;


        [Inject]
        public void Initialize(
            IInputService inputService, GameData gameData,
            GameStateMachine stateMachine, CellMover cellMover,
            TileSpawner tileSpawner
        ) {
            _gameData = gameData;
            _cellMover = cellMover;
            _tileSpawner = tileSpawner;
            
            _cellMover.InitializeCells(transform);
            inputService.Swipe += Turn;
            _tileSpawner.SpawnTile();
        }

        private void Turn(Vector2 direction) {
            _cellMover.MoveCells(direction);
            ScoreUpdate();

            _cellMover.EndTurn();
            _tileSpawner.SpawnTile();
            
        }

        private void ScoreUpdate() {
            _gameData.UpdateScore(
                _cellMover.GetMergedValues
            );
        }

    }

}