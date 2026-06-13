using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI kittyCatCount;
    public GameObject restartButton;
    public GameObject winText;
    public GameObject door;
    
    public GameObject winBox;
    public float spawnKitty = 15f;
    public float spawnTime = 1;
    public GameObject kittyCat;
    public float initialTime = 60f;
    private Boolean con = false;

    public AudioClip chompAudio;
    public AudioClip biteAudio;
    public AudioClip materializeCatAudioOne;
    public AudioClip materializeCatAudioTwo;
    public AudioClip materializeCatAudioThree;
    public AudioClip winOne;
    public AudioClip winTwo;
    

    private AudioSource playerAudio;
    
    PlayerInput playerInput;

    public float speed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kittyCatCount.color = Color.red;
        
       
        rb = GetComponent <Rigidbody>();
        count = 0f;
        winText.SetActive(false);
        restartButton.SetActive(false);
        winBox.SetActive(false);
        playerAudio = GetComponent<AudioSource>();
        kittyCatCount.text = "Kitty Cats: " + spawnTime.ToString();
        objectiveText.text = "Objective: Collect 5 cheese items.";

        playerAudio.PlayOneShot(materializeCatAudioOne, 1f);


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

        if (con == false)
        {
            if (initialTime > 0)
            {
                initialTime -= Time.deltaTime;


            }
            else
            {
                initialTime = 0;
            }

            if (initialTime <= 10)
            {
                timerText.color = Color.red;
            }


        }



        timerText.text = Mathf.RoundToInt(initialTime).ToString();



        if (initialTime == 0 && con == false)
        {
            gameObject.SetActive(false);

            winText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!!!";
            con = true;
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
            int randomSound = UnityEngine.Random.Range(1, 3);

            if (randomSound == 1)
            {
                playerAudio.PlayOneShot(chompAudio, 1f);
            }
            else
            {
                playerAudio.PlayOneShot(biteAudio, 1f);
            }

            
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCount();

            if(count == 5)
            {
                objectiveText.text = "Objective: Escape through the back door!";
                door.SetActive(false);
                winBox.gameObject.SetActive(true);
               
            }
        }

       if (other.gameObject.CompareTag("Win"))
        {
            int randomSound = UnityEngine.Random.Range(1, 3);
            if (randomSound == 1)
            {
                playerAudio.PlayOneShot(winOne, 1f);
            }
            else if (randomSound == 2)
            {
                playerAudio.PlayOneShot(winTwo, 1f);
            }

            con = true;
            restartButton.gameObject.SetActive(true);
            winText.SetActive(true);

            objectiveText.text = "Objective: You did it!!!!";

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i], 5f);
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
            gameObject.SetActive(false);

            restartButton.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!!!";
        }

    }

    void SpawnKitty()
    {
        if (con ==false)
        {
            if (initialTime > 0)
            {
                if (initialTime <= 60 - spawnKitty * spawnTime)
                {
                    int randomSound = UnityEngine.Random.Range(1, 4);

                    if (randomSound == 1)
                    {
                        playerAudio.PlayOneShot(materializeCatAudioOne, 0.5f);
                    }
                    else if(randomSound == 2)
                    {
                        playerAudio.PlayOneShot(materializeCatAudioTwo, 0.5f);
                    }
                    else if(randomSound ==3)
                    {
                        playerAudio.PlayOneShot(materializeCatAudioThree, 0.5f);
                    }

                    Instantiate(kittyCat, new Vector3(-10, 0, 27.5f), Quaternion.identity);
                    kittyCat.tag = "Enemy";
                    spawnTime = spawnTime + 1;
                    kittyCatCount.text = "Kitty Cats: " + spawnTime.ToString();
                    SpawnKitty();

                }
            }
        }



    }


}
