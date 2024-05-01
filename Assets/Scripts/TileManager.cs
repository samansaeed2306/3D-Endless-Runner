using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] titlePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;

    // Start is called before the first frame update
    void Start()
    {
        if (titlePrefabs.Length == 0)
        {
            Debug.LogError("No tile prefabs assigned to TileManager.");
            return;
        }

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                int randomIndex = Random.Range(0, titlePrefabs.Length);
                SpawnTile(randomIndex);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnTile(int titleIndex)
    {
        Instantiate(titlePrefabs[titleIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
    }
}
