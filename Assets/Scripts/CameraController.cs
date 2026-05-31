using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private float zPos;
    private float xPos;
    private float yPos;
    public float rightBound = 12;
    public float leftBound = -12;
    public float xBoundary = 8;
    public float yBoundary = 3;
    private Vector3 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zPos = transform.position.z;
        pos = transform.position;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pos = player.transform.position + offset;

        transform.position = pos;

        if (transform.position.z > rightBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, rightBound);
           
        }

        if (transform.position.z < leftBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, leftBound);
        }
        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }

        if (transform.position.y > yBoundary)
        {
            transform.position = new Vector3(transform.position.x, yBoundary, transform.position.z);
        }



        



      

        

        

       

        
    }
}
