using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class GameField : MonoBehaviour {

    [SerializeField] private Tile TilePrefab;

    private Cell[,] _cells = new Cell[4, 4];

    private Random _randomService;
    private GameFactory _gameFactory;

    public void Initialize() {
        _randomService = new Random();
        CreateField();
        SpawnTile();
    }

    private void CreateField() {
        _gameFactory = new GameFactory();
        _cells = _gameFactory.CreateCells(transform);
    }


    public void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MoveLeft();
            SpawnTile();
        }
    }

    private void MoveLeft() {
        for (int i = 0; i < 4; i++) {
            for (int j = 3; j > 0; j--) {

                if (_cells[i, j].TryMerge(_cells[i, j - 1].Tile, Direction.Left))
                    _cells[i, j - 1].Clear();
            }
        }

        foreach (Cell cell in _cells) {
            cell.Apply();
        }
    }

//transfer to factory && delete tiles list
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