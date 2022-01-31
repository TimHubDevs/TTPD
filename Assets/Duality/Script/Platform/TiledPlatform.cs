using UnityEngine;

public class TiledPlatform : MonoBehaviour
{
    public void SpawnTiles(GameObject tilePrefab, int[] tilesToDelete, Sprite[] tileVars, GameObject[] enemyPrefs,
        int[] tilesToSpawnWhite, int[] tilesToSpawnBlack)
    {
        for (int i = 0; i < 18; i++)
        {
            GameObject tile = Instantiate(tilePrefab, transform.position + new Vector3(i * 2, 0, 0),
                Quaternion.identity);
            tile.transform.SetParent(transform);
            tile.GetComponent<SpriteRenderer>().sprite = tileVars[Random.Range(0, tileVars.Length)];

            foreach (var item in tilesToSpawnWhite)
            {
                if (item == i && tile.tag != "Spawned")
                {
                    if (enemyPrefs.Length <= 0) continue;
                    GameObject white = Instantiate(enemyPrefs[Random.Range(enemyPrefs.Length / 2, enemyPrefs.Length)],
                        tile.transform.position + new Vector3(0, 2.3f, 0), Quaternion.identity);
                    white.transform.SetParent(tile.transform);
                    tile.tag = "Spawned";
                }
            }

            foreach (var item in tilesToSpawnBlack)
            {
                if (item == i && tile.tag != "Spawned")
                {
                    if (enemyPrefs.Length <= 0) continue;
                    GameObject black = Instantiate(enemyPrefs[Random.Range(0, enemyPrefs.Length / 2)],
                        tile.transform.position - new Vector3(0, 2.3f, 0), Quaternion.Euler(0, 0, 180));
                    black.transform.SetParent(tile.transform);
                    tile.tag = "Spawned";
                }
            }

            foreach (var item in tilesToDelete)
            {
                if (item == i)
                {
                    Destroy(tile.gameObject);
                    continue;
                }
            }
        }
    }
}