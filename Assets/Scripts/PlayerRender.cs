using UnityEngine;
using TMPro;

public class PlayerRender : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    public AudioSource audio;
    public TextMeshProUGUI winText;
    private bool playOnce = false;


    public AudioClip lose;

    //public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        if (winText.text == "You Lose!!!" && playOnce == false)
        {
            audio.PlayOneShot(lose, 1f);
            playOnce = true;
        }

    }
}
