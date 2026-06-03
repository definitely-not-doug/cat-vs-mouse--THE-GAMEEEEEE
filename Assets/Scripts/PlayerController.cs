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
    public TextMeshProUGUI timerText;
    public GameObject winText;
    public GameObject door;
    public GameObject winBox;
    public float spawnKitty = 15f;
    public float spawnTime = 1;
    public GameObject kittyCat;
    public float initialTime = 60f;
    
    PlayerInput playerInput;

    public float speed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

       
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

    void Update()
    {
        SpawnKitty();
        if (initialTime > 0)
        {
            initialTime -= Time.deltaTime;
            

        }
        else
        {
            initialTime = 0;
        }

        
        
        timerText.text = Mathf.RoundToInt(initialTime).ToString();



        if (initialTime == 0)
        {
            Destroy(gameObject);

            winText.gameObject.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!!!";
        }





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

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
           
        }

        
    }

    void SetCount()
    {
        countText.text = "Cheese: " + count.ToString();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            winText.gameObject.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!!!";
        }

    }

    void SpawnKitty()
    {
        if (initialTime > 0)
        {
            if (initialTime <= 60 - spawnKitty * spawnTime)
            {
                Instantiate(kittyCat, new Vector3(-10, 0, 27.5f), Quaternion.identity);
                kittyCat.tag = "Enemy";
                spawnTime = spawnTime + 1;
                SpawnKitty();

            }
        }


    }
}
