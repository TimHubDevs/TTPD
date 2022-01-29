using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject tilePrefab;
    public Sprite[] tileVariants;
    public GameObject platformPrefab;
    void Start()
    {
        SpawnPlatforms();
    }
    public void SpawnPlatforms()
    {
        for (int i = 0; i < 200; i++)
        {
            int[] toDelete = new int[Random.Range(2,7)];
            for (int t = 0; t< toDelete.Length; t++)
            {
                toDelete[t] = i%2==0 ? Random.Range(18-1, 18-8) : Random.Range(0, 7);
            }

            GameObject platform = Instantiate(platformPrefab, transform.position + new Vector3(-15, -i * 6, 0), Quaternion.identity);
            platform.transform.SetParent(transform);
            platform.GetComponent<TiledPlatform>().SpawnTiles(tilePrefab, toDelete, tileVariants);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
