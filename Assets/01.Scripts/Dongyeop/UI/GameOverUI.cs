using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;

    private float _bestScore;
    private float _socre;
    
    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    public void Init(float score)
    {
        _socre = score;
        _bestScore = PlayerPrefs.GetFloat("BestScore");
        if (_bestScore < _socre)
        {
            _bestScore = _socre;
            PlayerPrefs.SetFloat("BestScore", _bestScore);
            print(_bestScore);
        }
        
        GameOverUIShow();
    }

    private void GameOverUIShow()
    {
        _root = _uiDocument.rootVisualElement;

        Label currentScoreTxt = _root.Q<Label>("CurrentScore");
        currentScoreTxt.text = "Current Score\n" + Math.Truncate(_socre * 100) / 100;
        Label beseScoreTxt = _root.Q<Label>("BestScore");
        beseScoreTxt.text = "Best Score\n" + Math.Truncate(_bestScore * 100) / 100;

        Button titleButton = _root.Q<Button>("TitleButton");
        titleButton.RegisterCallback<ClickEvent>(evt => SceneManager.LoadScene(0));
        Button restartButton = _root.Q<Button>("RestartButton");
        restartButton.RegisterCallback<ClickEvent>(evt => SceneManager.LoadScene(1));
    }
}
