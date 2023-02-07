using Entities;
using Services;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace Infrastructure.Kernel.Field {

    public class GameField : MonoBehaviour {

        private CellMover _cellMover;
        private GameData _gameData;
        private GameFactory _gameFactory;
        private Random _random;

        private Cell[,] _cells = new Cell[4, 4];
        private int _filled = 0;

        [Inject]
        public void Initialize(
            IInputService inputService, GameData gameData,
            CellMover cellMover, GameFactory gameFactory
        ) {
            _gameData = gameData;
            _cellMover = cellMover;
            _gameFactory = gameFactory;
            _random = new Random();

            _cells = _gameFactory.CreateCells(transform);
            inputService.Swipe += Turn;
            SpawnTile();
        }

        private void Turn(Vector2 direction) {
            if (_cellMover.MoveCells(_cells, direction)) {
                ScoreUpdate();
                FieldUpdate();
                FinishChecker();
                _cellMover.EndTurn();
            }
        }

        private void FinishChecker() {
            if (_filled == 16 && !CheckPairs()) {
                Debug.Log("GameOver");
            }
            SpawnTile();
        }

        private bool CheckPairs() {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (_cells[i, j].GetValue == _cells[i + 1, j].GetValue ||
                        _cells[i, j].GetValue == _cells[i, j + 1].GetValue) {
                        return true;
                    }
                }

                for (int k = 3, j = 0; j < 3; j++) {
                    if (_cells[k, j].GetValue == _cells[k, j + 1].GetValue ||
                        _cells[j, k].GetValue == _cells[j + 1, k].GetValue) {
                        return true;
                    }
                }
            }
            return false;
        }

        private void FieldUpdate() {
            foreach (Cell cell in _cells) {
                _filled -= cell.GetMerge;
                cell.Apply();
            }
        }

        private void SpawnTile() {
            Cell emptyCell = GetEmptyCell();
            Tile tile = _gameFactory.InstantiateTile(emptyCell.transform);
            emptyCell.Tile = tile;
            tile.Appear();
            _filled += 1;
        }

        private Cell GetEmptyCell() {
            Cell emptyCell = _cells[_random.Next(0, 4), _random.Next(0, 4)];
            while (emptyCell.GetValue != 0) {
                emptyCell = _cells[_random.Next(0, 4), _random.Next(0, 4)];
            }
            return emptyCell;
        }

        private void ScoreUpdate() {
            int cellScore = 0;
            foreach (Cell cell in _cells) {
                cellScore += cell.GetScore();
            }

            _gameData.UpdateScore(cellScore);
        }

    }

}