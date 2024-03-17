using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos2 : MonoBehaviour
{
    public Vector3 Position;
    public static float PosX;
    public static float PosY;
    public static float PosZ;

    void Update()
    {
        PosX = gameObject.transform.position.x;
        PosY = gameObject.transform.position.y;
        PosZ = gameObject.transform.position.z;

        Position = new Vector3(PosX, PosY, PosZ);
    }
}
