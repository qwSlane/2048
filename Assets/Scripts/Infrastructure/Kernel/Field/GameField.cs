using System.Threading.Tasks;
using Entities;
using Services;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace Infrastructure.Kernel.Field {

    public class GameField : MonoBehaviour {

        private Cell[,] _cells = new Cell[4, 4];

        private Random _randomService;
        private GameFactory _gameFactory;

        private bool _isMooved;
        private GameData _gameData;

        private int _stepScore;
        

        [Inject]
        public void Initialize(
            IInputService inputService, GameFactory gameFactory,
            Random randomService, GameData gameData
        ) {
            _gameData = gameData;
            _randomService = randomService;
            _gameFactory = gameFactory;
            
            _cells = _gameFactory.CreateCells(transform);
            
            inputService.Swipe += Swipe;
            
            SpawnTile();
        }

        private void Swipe(Vector2 direction) {
            if (direction is { x: > 0, y: > 0 }) {
                MoveUp();
            }
            else if (direction is { x: > 0, y: < 0 }) {
                MoveRight();
            }
            else if (direction is { x: < 0, y: < 0 }) {
                MoveDown();
            }
            else if (direction is { x: < 0, y: > 0 }) {
                MoveLeft();
            }
            
            TileMoves();
            ScoreUpdate();
        }

        private void ScoreUpdate() {
            _gameData.UpdateScore(_stepScore);
            _stepScore = 0;
        }

        private async void TileMoves() {
            if (_isMooved) {
                foreach (Cell cell in _cells) {
                    _stepScore += cell.Apply();
                }
                await Task.Delay(300);
                SpawnTile();
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

        private void SpawnTile() {
            Cell cell = GetRandomCell();
            Tile tile = _gameFactory.InstantiateTile(cell.transform);
            cell.Tile = tile;
            tile.Appear();
        }

        private Cell GetRandomCell() {
            Cell cell = _cells[_randomService.Next(0, 4), _randomService.Next(0, 4)];
            while (cell.GetValue != 0) {
                cell = _cells[_randomService.Next(0, 4), _randomService.Next(0, 4)];
            }
            return cell;
        }

    }

}