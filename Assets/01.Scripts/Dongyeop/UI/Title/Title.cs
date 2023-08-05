using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Title : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;

    private Button _startButton;
    private Button _loadButton;
    private Button _settingButton;
    private Button _exitButton;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _root = _uiDocument.rootVisualElement;

        _startButton = _root.Q<Button>("StartButton");
        _startButton.RegisterCallback<ClickEvent>(evt => SceneManager.LoadScene(1));
        _loadButton = _root.Q<Button>("LoadButton");
        _loadButton.RegisterCallback<ClickEvent>(evt => { /* 차후 개발 */ });
        _settingButton = _root.Q<Button>("SettingButton");
        _settingButton.RegisterCallback<ClickEvent>(evt => { /* 차후 개발 */ });
        _exitButton = _root.Q<Button>("ExitButton");
        _exitButton.RegisterCallback<ClickEvent>(evt => Application.Quit());
    }
}
