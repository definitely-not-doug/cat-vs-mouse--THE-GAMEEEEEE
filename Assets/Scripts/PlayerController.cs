using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI objectiveText;
    public GameObject winText;
    public GameObject door;
    public GameObject winBox;
    
    PlayerInput playerInput;

    public float speed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerInput = GetComponent<PlayerInput>();
       // InputSystem.actions.Disable();
        //playerInput.currentActionMap?.Enable();
       
        rb = GetComponent <Rigidbody>();
        count = 0f;
        winText.SetActive(false);
        objectiveText.text = "Objective: Collect 5 cheese items.";
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCount();

            if(count == 5)
            {
                objectiveText.text = "Objective: Escape through the back door!";
                door.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("Win"))
        {
            winText.SetActive(true);
            objectiveText.text = "Objective: You did it!!!!";
        }

        
    }

    void SetCount()
    {
        countText.text = "Count: " + count.ToString();
        
    }
}
