using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    public float height, width, startposY, startposX;
    public GameObject cam;
    public float power;
    private void Start()
    {
        startposY = transform.position.y;
        startposX = transform.position.x;
        height = GetComponentInChildren<SpriteRenderer>().bounds.size.y;
        width = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        float tempY = cam.transform.position.y * (1 - power);
        float distanceY = (cam.transform.position.y * power);

        float tempX = cam.transform.position.x * (1 - power);
        float distanceX = (cam.transform.position.x * power);

        transform.position = new Vector3(startposX+distanceX, startposY + distanceY, transform.position.z);

        if (tempY > startposY + height)
            startposY += height;
        else if (tempY < startposY - height)
            startposY -= height;

        if (tempX > startposX + width)
            startposX += width;
        else if (tempX < startposX - width)
            startposX -= width;
    }
}
