using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState _state;
    private List<IComponent> _components = new List<IComponent>();

    [HideInInspector] public GameObject Player;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager is running");
        Instance = this;
        
        Player = GameObject.Find("Player");
    }

    private void Start()
    {
        AddComponent();
        UpdateState(GameState.INIT);
    }

    public void UpdateState(GameState state)
    {
        _state = state;
        
        foreach (var component in _components)
            component.UpdateState(state);
        
        if (state == GameState.INIT)
            UpdateState(GameState.RUNNING);
    }

    private void AddComponent()
    {
        _components.Add(FindObjectOfType<PlayerController>());
    }
}
