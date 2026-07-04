using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    PlayerInput playerInput;
    InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        Debug.Log(moveAction.ReadValue<Vector2>());
    }
}
