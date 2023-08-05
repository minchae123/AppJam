using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        currentScoreTxt.text = "Current Score\n" + _socre;
        Label beseScoreTxt = _root.Q<Label>("BestScore");
        beseScoreTxt.text = "Best Score\n" + _bestScore;
    }
}
