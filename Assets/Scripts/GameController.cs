using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel;

    [SerializeField]
    private Transform _playerSpawnPos;

    [SerializeField]
    private List<GameObject> _players = new(4);

    [SerializeField]
    private ScoreCounter _scoreCounter;

    [SerializeField]
    private ObtacleSpawner _obtacleSpawner;

    private readonly string _levelKey = "Level";

    private readonly string _maxLevelKey = "MaxLevel";
     
    private string _currentBoatKey = "CurrentBoat";

    private int _currentLevel;

    private int _currentBoat;

    private int _maxLevel;

    private bool _isGameOver = false;

    private List<float> _spawnTimeByLevel = new(5) { 1.5f, 1.3f, 1.0f, 0.8f, 0.5f };

    private List<int> _levelScoreList = new(4) {80, 100, 150, 300 };

    public int GameTime { get => (int)_gameSessionTime; }

    private float _gameSessionTime = 120f;

    private int _finalScore = 0;

    [HideInInspector]
    public UnityEvent IsGameOver;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey(_levelKey))
            PlayerPrefs.SetInt(_levelKey, 0);

        if (!PlayerPrefs.HasKey(_maxLevelKey))
            PlayerPrefs.SetInt(_maxLevelKey, 0);

        _maxLevel = PlayerPrefs.GetInt(_maxLevelKey);

        _currentLevel = PlayerPrefs.GetInt(_levelKey);

        _currentBoat = PlayerPrefs.GetInt(_currentBoatKey);

        Instantiate(_players[_currentBoat], _playerSpawnPos.position, Quaternion.identity);

        IsGameOver = new UnityEvent();
    }

    private void Start()
    {
        _obtacleSpawner.SpawnTime = _spawnTimeByLevel[_currentLevel];

        Debug.Log("CURRENT LEVEL " + _currentLevel + " MAX LEVEL " + _maxLevel);
    }

    private void GameOver()
    {
        Debug.Log("Game over!");
        _isGameOver = true;

        if (_scoreCounter != null)
            _finalScore = _scoreCounter.Score;

        Debug.Log("Final score" + _finalScore);

        if (_currentLevel != _levelScoreList.Count)
        {
            if (_currentLevel == _maxLevel && _finalScore >= _levelScoreList[_currentLevel])
            {
                _maxLevel++;
                PlayerPrefs.SetInt(_maxLevelKey, _maxLevel);
                Debug.Log("MAX LVL " + PlayerPrefs.GetInt(_maxLevelKey));
            }
        }

        IsGameOver.Invoke();

        _gameOverPanel.SetActive(true);
    }

    private void Update()
    {
        _gameSessionTime -= Time.deltaTime;

        if (_gameSessionTime < 0 && !_isGameOver)
        {
            GameOver();
        }
    }

}
