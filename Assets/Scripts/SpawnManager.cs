using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject cheesePrefab;

    private float spawnRate = 10.0f;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        StartCoroutine(Cheese());

    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private Vector3 GenerateSpawnPos()
    {
        Vector3 randomPos;
        Collider[] colliders;

        do
        {
            float spawnPosX = Random.Range(-2.5f, 3);
            float spawPosZ = Random.Range(-20, 36);
             randomPos = new Vector3(spawnPosX, 1.25f, spawPosZ);

            colliders = Physics.OverlapSphere(randomPos, 0.5f);
        }

        while (colliders.Length > 0);

        return randomPos;
    }

    void SpawnCheese()
    {
        for (int i = 0; i < 5; i++)
        {
            
            Instantiate(cheesePrefab, GenerateSpawnPos(), cheesePrefab.transform.rotation);


        }

    }

    IEnumerator Cheese()
    {
        yield return new WaitForSeconds(spawnRate * Time.deltaTime);

        SpawnCheese();
    }
}
