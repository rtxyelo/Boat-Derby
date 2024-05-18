using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _obtaclePrefabs = new();

    [SerializeField]
    private List<Transform> _spawnPositions = new();

    private bool SpawnAllow = true;

    private float _spawnTime = 2.0f;

    private float _error = 0.17f;

    public float SpawnTime { get { return _spawnTime; } set { _spawnTime = value; } }

    private GameController _gameController;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        _gameController.IsGameOver.AddListener(GameOver);
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (SpawnAllow)
        {
            float spawnTime = Random.Range(_spawnTime - _error, _spawnTime);

            int spawnIndex = Random.Range(0, _spawnPositions.Count);
            int obtacleIndex = Random.Range(0, _obtaclePrefabs.Count);

            Instantiate(_obtaclePrefabs[obtacleIndex], _spawnPositions[spawnIndex].transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void GameOver()
    {
        SpawnAllow = false;

        gameObject.SetActive(false);
    }
}
