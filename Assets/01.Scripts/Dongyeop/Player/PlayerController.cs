using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IComponent
{
    public AgentData _playerData;
    private List<IPlayerComponent> _components = new List<IPlayerComponent>();

    [HideInInspector] public Rigidbody2D Rigidbody2D;
    public float rayDis;
    [SerializeField] private LayerMask ground;
    private Collider2D _collider;

    private void Awake()
    {
        AddComponents();
    }

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        //개씹 하드코딩이지만 일단은 함 ^0^
        if (_collider.IsTouchingLayers(ground))
            PlayerInput.Instance.isJump = false;
        else
            PlayerInput.Instance.isJump = true;
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
