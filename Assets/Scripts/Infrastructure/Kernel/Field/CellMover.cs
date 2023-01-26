using System.Threading.Tasks;
using Entities;
using Services;
using UnityEngine;

namespace Infrastructure.Kernel.Field {

    public class CellMover {

        private readonly GameFactory _gameFactory;

        private Cell[,] _cells = new Cell[4, 4];
        private bool _isMooved;
        private int _stepScore;

        public int GetMergedValues => _stepScore;

        public CellMover(GameFactory gameFactory) {
            _gameFactory = gameFactory;
        }

        public void InitializeCells(Transform parent) {
            _cells = _gameFactory.CreateCells(parent);
        }

        public Cell GetCell(int i) => 
            _cells[i / 4, 1 % 4];

        public void MoveCells(Vector2 to) {
            if (to is { x: > 0, y: > 0 }) {
                MoveUp();
            }
            else if (to is { x: > 0, y: < 0 }) {
                MoveRight();
            }
            else if (to is { x: < 0, y: < 0 }) {
                MoveDown();
            }
            else if (to is { x: < 0, y: > 0 }) {
                MoveLeft();
            }

            TileMoves();
        }

        public void EndTurn() {
            _stepScore = 0;
        }

        private async void TileMoves() {
            if (_isMooved) {
                foreach (Cell cell in _cells) {
                    _stepScore += cell.Apply();
                }
                await Task.Delay(300);
                _isMooved = false;
            }
        }

        private void MoveRight() {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 3; j++) {
                    if (_cells[i, j].TryMerge(_cells[i, j + 1].Tile, Direction.Right)) {
                        _cells[i, j + 1].Clear();
                        _isMooved = true;
                    }
                }
            }
        }

        private void MoveLeft() {
            for (int i = 0; i < 4; i++) {
                for (int j = 3; j > 0; j--) {
                    if (_cells[i, j].TryMerge(_cells[i, j - 1].Tile, Direction.Left)) {
                        _cells[i, j - 1].Clear();
                        _isMooved = true;
                    }
                }
            }
        }

        private void MoveUp() {
            for (int j = 0; j < 4; j++) {
                for (int i = 3; i > 0; i--) {
                    if (_cells[i, j].TryMerge(_cells[i - 1, j].Tile, Direction.Up)) {
                        _cells[i - 1, j].Clear();
                        _isMooved = true;
                    }
                }
            }
        }

        private void MoveDown() {
            for (int j = 0; j < 4; j++) {
                for (int i = 0; i < 3; i++) {
                    if (_cells[i, j].TryMerge(_cells[i + 1, j].Tile, Direction.Down)) {
                        _cells[i + 1, j].Clear();
                        _isMooved = true;
                    }
                }
            }
        }

    }

}