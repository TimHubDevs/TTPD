using System.Collections;
using UnityEngine;

public class Kaban : MonoBehaviour
{
    public GameObject seekerL, seekerR;
    public LayerMask gro;
    public int isBlack;

    public bool turn = false;
    public int dir = 1;

    private void Start()
    {
       
        turn = false;
        dir = 1 * isBlack;
    }

    private void Update()
    {
        Collider2D[] hitL;
        hitL = Physics2D.OverlapCircleAll(seekerL.transform.position, 0.01f, gro);
        Collider2D[] hitR;
        hitR = Physics2D.OverlapCircleAll(seekerR.transform.position, 0.01f, gro);
        if (hitL.Length > 0 && hitR.Length > 0)
        {
            turn = false;
        }

        if (hitR.Length == 0 && !turn)
        {
            StartCoroutine(Flip(dir));
        }

        if (hitL.Length == 0 && !turn)
        {
            StartCoroutine(Flip(dir));
        }

        Move(-dir);
    }

    private IEnumerator Flip(int direct)
    {
        turn = true;
        dir = 0;
        yield return new WaitForSeconds(1f);
        dir = direct * -1;
        if (dir == 1 * isBlack)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
    }

    private void Move(int dir)
    {
        transform.position += new Vector3(dir * 4 * Time.deltaTime, 0, 0);
    }
}