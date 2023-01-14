using System;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    private Tile _currentTile;
    private readonly Dictionary<Direction, Cell> _neighbours = new Dictionary<Direction, Cell>();
    [SerializeField] private List<Tile> _mergedTiles = new List<Tile>();
    private bool _isMerged;
    public int GetValue => (_currentTile) ? _currentTile.Value : 0;

    public event Func<Transform, int, Tile> GetNewTile;

    public void SetNeighbours(Cell left, Cell right, Cell up, Cell down) {
        _neighbours[Direction.Left] = left;
        _neighbours[Direction.Right] = right;
        _neighbours[Direction.Up] = up;
        _neighbours[Direction.Down] = down;
    }

    public Tile Tile {
        get => _currentTile;
        set {
            if (!_currentTile) {
                _currentTile = value;
            }
        }
    }

    public bool TryMerge(Tile merged, Direction direction) {
        if (merged) {
            return Merging(merged) || TryAdd(merged, direction);
        }
        return false;
    }

    public void Apply() {
        if (_isMerged) {
            foreach (Tile tile in _mergedTiles) {
                tile.Merge();
            }
            _isMerged = false;
            _currentTile.Appear();
            _mergedTiles.Clear();
        }
        _currentTile?.Move();
    }

    private bool TryAdd(Tile merged, Direction direction) {
        if (_currentTile == null) {
            AddTile(merged);
            PushNext(merged, direction);
            return true;
        }
        return false;
    }

    private bool Merging(Tile merged) {
        if (_currentTile?.Value == merged.Value &&!_isMerged) {
            PrepareTiles(merged);
            _currentTile = GetNewTile?.Invoke(transform, _currentTile.Value * 2);
            _isMerged = true;
            return true;
        }
        return false;
    }

    private void AddTile(Tile merged) {
        _currentTile = merged;
        _currentTile.transform.SetParent(transform);
    }

    private void PushNext(Tile merged, Direction direction) {
        if (_neighbours[direction] && _neighbours[direction].TryMerge(merged, direction))
            Clear();
    }

    private void PrepareTiles(Tile merged) {
        merged.transform.SetParent(transform);
        _mergedTiles.Add(merged);
        _mergedTiles.Add(_currentTile);
    }


    public void Clear() {
        _currentTile = null;
    }

}