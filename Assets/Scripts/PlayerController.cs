using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    
    PlayerInput playerInput;

    public float speed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerInput = GetComponent<PlayerInput>();
       // InputSystem.actions.Disable();
        //playerInput.currentActionMap?.Enable();
       
        rb = GetComponent <Rigidbody>();
    }

    // Update is called once per frame

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //add force needs a vector3 variable
        rb.AddForce(movement * speed);


    }
}
