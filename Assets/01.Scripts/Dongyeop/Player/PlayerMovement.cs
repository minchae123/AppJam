using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.RUNNING:
                Initialize();
                break;
            case GameState.STANDBY:
            case GameState.GAMEOVER:
                DeInitialize();
                break;
        }
    }

    private void Initialize()
    {
        PlayerInput.Instance.PlayerXInput += PlayerMove;
        PlayerInput.Instance.PlayerSpaceInput += PlayerJump;
    }
    
    private void DeInitialize()
    {
        PlayerInput.Instance.PlayerXInput -= PlayerMove;
        PlayerInput.Instance.PlayerSpaceInput -= PlayerJump;
    }

    private void PlayerMove(Vector2 pos)
    {
        transform.Translate(pos * (_playerController._playerData.Speed * Time.deltaTime));
    }

    private void PlayerJump()
    {
        print(Vector2.up * _playerController._playerData.JumpScale);
        _playerController.Rigidbody2D.AddForce(Vector2.up * _playerController._playerData.JumpScale, ForceMode2D.Impulse);
    }
}
