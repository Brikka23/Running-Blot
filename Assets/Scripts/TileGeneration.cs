using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject[] _tilePrefabs;

    private List<GameObject> _activeTiles = new List<GameObject>();

    private int _startTiles = 6;
    private float _spawnPos = 0f;
    private float _tileLength = 100f;

    private void Start()
    {
        for (int i = 0; i < _startTiles; i++)
        {
            SpawnTile(Random.Range(0, _tilePrefabs.Length));
        }
    }

    private void Update()
    {
        if (_playerTransform.position.z - 60 > _spawnPos - (_startTiles * _tileLength))
        {
            SpawnTile(Random.Range(0, _tilePrefabs.Length));
            DeleteTile();
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(_tilePrefabs[tileIndex], transform.forward * _spawnPos, transform.rotation);
        _activeTiles.Add(nextTile);
        _spawnPos += _tileLength;
    }

    private void DeleteTile()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }
}
