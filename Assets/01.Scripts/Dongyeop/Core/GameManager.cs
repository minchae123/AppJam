using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private InGameUI _inGameUI;
    private GameObject _gameOverUI;
    private float _score;
    public float Score
    {
        get => _score;
        set
        {
            _score = value;
            _inGameUI.ScoreUpdate(_score);
        } 
    }

    private bool _isGameOver = false;
    public bool IsGameOver => _isGameOver;
    

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;
    }

    private void Start()
    {
        _gameOverUI = GameObject.Find("GameOverUI");
        _inGameUI = _gameOverUI.transform.root.GetChild(1).GetComponent<InGameUI>();
        _gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        _isGameOver = true;
        _gameOverUI.SetActive(true);
        _gameOverUI.GetComponent<GameOverUI>().Init(_score);
    }
}
