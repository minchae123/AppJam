using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;

    public Action<Vector2> PlayerXInput;
    public Action PlayerSpaceInput;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple PlayerInput is running");
        Instance = this;
    }

    private void Update()
    {
        PlayerX();
        PlayerSpace();
    }

    private void PlayerX()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 pos = new Vector2(x, 0);
        PlayerXInput?.Invoke(pos);
    }

    private void PlayerSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayerSpaceInput?.Invoke();
    }
}
