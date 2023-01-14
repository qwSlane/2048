using System.Collections.Generic;
using Services.Assets;
using UnityEngine;

public class GameFactory {
    
    private readonly IAssetProvider _assetProvider;
    
    public GameFactory() {
        _assetProvider = new AssetProvider();
    }

    public Cell[,] CreateCells(Transform parent) {
        Cell[,] cells = new Cell[4, 4];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                Vector3 position = new Vector3(i * 4, (i + j) * .2f, j * 4);
                Cell cell = _assetProvider.GetAsset(AssetPath.CellPath, position, parent) 
                    .GetComponent<Cell>();
                cell.GetNewTile += InstantiateTile;
                cells[i, j] = cell;
            }
        }
        InitializeCells(cells);
        return cells;
    }

    public Tile InstantiateTile(Transform parent, int value = 2) {
        Tile tile = _assetProvider.GetAsset(AssetPath.Tiles[value], parent.position + parent.up, parent) 
            .GetComponent<Tile>();
        tile.transform.localScale = Vector3.zero;
        tile.Initialize(value);
        return tile;
    }

    private void InitializeCells(Cell[,] cells) {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                Cell left = null, right = null, up = null, down = null;

                if (j < 3) {
                    left = cells[i, j + 1];
                }

                if (j > 0) {
                    right = cells[i, j - 1];
                }

                if (i < 3) {
                    up = cells[i + 1, j];
                }

                if (i > 0) {
                    down = cells[i - 1, j];
                }

                cells[i, j].SetNeighbours(left, right, up, down);
            }
        }
    }

}