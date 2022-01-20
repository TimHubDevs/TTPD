using UnityEngine;

public class Test
{
    static bool CheckIsFar(Vector3 pos1, Vector3 pos2, float distance)
    {
        // return Vector3.Distance(pos1, pos2) > distance;
        Vector3 vector3 = pos1 - pos2;
        return Vector3.SqrMagnitude(vector3) > distance*distance;
    }
}
