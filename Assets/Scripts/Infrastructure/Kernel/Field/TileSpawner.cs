using System;
using Entities;

namespace Infrastructure.Kernel.Field {

    public class TileSpawner {

        private CellMover _cellMover;
        private GameFactory _gameFactory;
        private Random _random;

        public TileSpawner(CellMover cellMover, GameFactory gameFactory) {
            _random = new Random();
            _cellMover = cellMover;
            _gameFactory = gameFactory;
        }

        public void SpawnTile() {
            Cell emptyCell = GetEmptyCell();           
            Tile tile = _gameFactory.InstantiateTile(emptyCell.transform);
            emptyCell.Tile = tile;
            tile.Appear();
        }

        private Cell GetEmptyCell() {
            Cell emptyCell = _cellMover.GetCell(_random.Next(0,15));
            while (emptyCell.GetValue != 0) {
                emptyCell = _cellMover.GetCell(_random.Next(0,15));
            }
            return emptyCell;
        }

    }

}