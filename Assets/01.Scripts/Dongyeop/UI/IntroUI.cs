using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class IntroUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _root = _uiDocument.rootVisualElement;

        Button startButton = _root.Q<Button>("StartButton");
        startButton.RegisterCallback<ClickEvent>(evt => SceneManager.LoadScene(1));
        Button exitButton = _root.Q<Button>("ExitButton");
        exitButton.RegisterCallback<ClickEvent>(evt => Application.Quit());
        
    }
}
