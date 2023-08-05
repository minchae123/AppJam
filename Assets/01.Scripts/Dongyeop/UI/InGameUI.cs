using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;
    private Label _label;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _root = _uiDocument.rootVisualElement;
        _label = _root.Q<Label>("Score");
    }

    public void ScoreUpdate(float value)
    {
        _label.text = (Math.Truncate(value * 100) / 100).ToString();
    }
}
