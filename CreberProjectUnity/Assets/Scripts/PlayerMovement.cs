using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private PlayerCamera playerCamera;

    private InputAction moveLeft, moveRight, moveForward, moveBackwards;

    public float speed = 5f, playerRotation;

    private Rigidbody rb;

    public Vector3 movement;

    private void Start()
    {
        playerCamera = GetComponent<PlayerCamera>();
        rb = GetComponent<Rigidbody>();

        // Basic input actions that I FINALLY enable with the code
        moveLeft = new InputAction(binding: "<Keyboard>/a");
        moveRight = new InputAction(binding: "<Keyboard>/d");
        moveForward = new InputAction(binding: "<Keyboard>/w");
        moveBackwards = new InputAction(binding: "<Keyboard>/s");
    }

    private void Update()
    {
        playerRotation = playerCamera.turn.x;

        Quaternion playerRotationQuaternion = Quaternion.Euler(0, playerRotation, 0);

        Vector3 forwardMovement = playerRotationQuaternion * Vector3.forward;
        Vector3 rightMovement = playerRotationQuaternion * Vector3.right;

        Vector3 movement = Vector3.zero;

        if (moveLeft.IsPressed())
        {
            movement += -rightMovement * speed;
        }

        if (moveRight.IsPressed())
        {
            movement += rightMovement * speed;
        }

        if (moveForward.IsPressed())
        {

            movement += forwardMovement * speed;
        }

        if (moveBackwards.IsPressed())
        {
            movement += -forwardMovement * speed;
        }

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    private void OnEnable()
    {
        moveLeft.Enable();
        moveRight.Enable();
        moveForward.Enable();
        moveBackwards.Enable();
    }

    private void OnDisable()
    {
        moveLeft.Disable();
        moveRight.Disable();
        moveForward.Disable();
        moveBackwards.Disable();
    }
}
