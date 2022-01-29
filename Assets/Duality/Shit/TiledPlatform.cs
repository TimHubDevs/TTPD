using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledPlatform : MonoBehaviour
{
    void Start()
    {
       
    }

    public void SpawnTiles(GameObject tilePrefab, int[] tilesToDelete, Sprite[] tileVars)
    {
        for (int i = 0; i < 18; i++)
        {
            GameObject tile = Instantiate(tilePrefab, transform.position + new Vector3(i * 2, 0, 0), Quaternion.identity);
            tile.transform.SetParent(transform);
            tile.GetComponent<SpriteRenderer>().sprite = tileVars[Random.Range(0, tileVars.Length)];
            foreach (var item in tilesToDelete)
            {
                if (item == i)
                {
                    Destroy(tile);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
