using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel;

    public int GameTime { get => (int)_gameSessionTime; }

    private float _gameSessionTime = 120f;

    [HideInInspector]
    public UnityEvent IsGameOver;

    public void Awake()
    {
        IsGameOver = new UnityEvent();
    }

    private void GameOver()
    {
        //Debug.Log("Game over!");

        IsGameOver.Invoke();

        _gameOverPanel.SetActive(true);
    }

    private void Update()
    {
        _gameSessionTime -= Time.deltaTime;

        if (_gameSessionTime < 0 )
        {
            GameOver();
        }
    }

}
