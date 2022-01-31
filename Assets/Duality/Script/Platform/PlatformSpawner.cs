using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject tilePrefab;
    public Sprite[] tileVariants;
    public GameObject[] enemyPrefs;
    public GameObject platformPrefab, lastPlatformPrefab;
    void Start()
    {
        SpawnPlatforms();
    }
    public void SpawnPlatforms()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i != 14)
            {
                int[] toDelete = new int[Random.Range(2, 7)];
                int[] toSpawnWhite = new int[Random.Range(1, 3)];
                int[] toSpawnBlack = new int[Random.Range(1, 3)];
                for (int t = 0; t < toDelete.Length; t++)
                {
                    toDelete[t] = i % 2 == 0 ? Random.Range(18 - 1, 18 - 8) : Random.Range(0, 7);
                }
                for (int t = 0; t < toSpawnBlack.Length; t++)
                {
                    toSpawnBlack[t] = Random.Range(0, 18);
                }
                for (int t = 0; t < toSpawnWhite.Length; t++)
                {
                    toSpawnWhite[t] = Random.Range(0, 18);
                }

                GameObject platform = Instantiate(platformPrefab, transform.position + new Vector3(-15, -i * 6, 0), Quaternion.identity);
                platform.transform.SetParent(transform);
                platform.GetComponent<TiledPlatform>().SpawnTiles(tilePrefab, toDelete, tileVariants, enemyPrefs, toSpawnWhite, toSpawnBlack);
            }
            else
            {
               // GameObject lastPlatform = Instantiate(lastPlatformPrefab, transform.position + new Vector3(-15, -i * 6, 0), Quaternion.identity);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
