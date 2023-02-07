using Entities;
using UnityEngine;

namespace Infrastructure.Kernel.Field {

    public class CellMover {

        private bool _isMooved;

        public bool MoveCells(Cell[,] cells, Vector2 to) {
            if (to is { x: > 0, y: > 0 }) {
                MoveUp(cells);
            }
            else if (to is { x: > 0, y: < 0 }) {
                MoveRight(cells);
            }
            else if (to is { x: < 0, y: < 0 }) {
                MoveDown(cells);
            }
            else if (to is { x: < 0, y: > 0 }) {
                MoveLeft(cells);
            }

            return _isMooved;
        }

        private void MoveRight(Cell[,] cells) {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 3; j++) {
                    if (cells[i, j].TryMerge(cells[i, j + 1].Tile, Direction.Right)) {
                        cells[i, j + 1].Clear();
                        _isMooved = true;
                    }
                }
            }
        }

        private void MoveLeft(Cell[,] cells) {
            for (int i = 0; i < 4; i++) {
                for (int j = 3; j > 0; j--) {
                    if (cells[i, j].TryMerge(cells[i, j - 1].Tile, Direction.Left)) {
                        cells[i, j - 1].Clear();
                        _isMooved = true;
                    }
                }
            }
        }

        private void MoveUp(Cell[,] cells) {
            for (int j = 0; j < 4; j++) {
                for (int i = 3; i > 0; i--) {
                    if (cells[i, j].TryMerge(cells[i - 1, j].Tile, Direction.Up)) {
                        cells[i - 1, j].Clear();
                        _isMooved = true;
                    }
                }
            }
        }

        private void MoveDown(Cell[,] cells) {
            for (int j = 0; j < 4; j++) {
                for (int i = 0; i < 3; i++) {
                    if (cells[i, j].TryMerge(cells[i + 1, j].Tile, Direction.Down)) {
                        cells[i + 1, j].Clear();
                        _isMooved = true;
                    }
                }
            }
        }

        public void EndTurn() {
            _isMooved = false;
        }

    }

}