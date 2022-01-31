using UnityEngine;

public class Platform : MonoBehaviour
{
    public int[] indexsesToDrop;
    public bool isRandom;

    private void Start()
    {
        foreach (int index in indexsesToDrop)
        {
            if (isRandom)
            {
                int newIndex = Random.Range(1, 10);
                Destroy(transform.GetChild(newIndex - 1).gameObject);
            }
            else
                Destroy(transform.GetChild(index - 1).gameObject);
        }
    }
}