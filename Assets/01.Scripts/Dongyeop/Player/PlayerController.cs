using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IComponent
{
    public AgentData _playerData;
    private List<IPlayerComponent> _components = new List<IPlayerComponent>();

    [HideInInspector] public Rigidbody2D Rigidbody2D;
    
    private void Awake()
    {
        AddComponents();
    }

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void AddComponents()
    {
        _components.Add(GetComponent<PlayerMovement>());
    }

    public void UpdateState(GameState state)
    {
        foreach (var playerComponent in _components)
            playerComponent.UpdateState(state);
    }
}
