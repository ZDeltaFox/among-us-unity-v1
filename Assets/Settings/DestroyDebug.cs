using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDebug : MonoBehaviour
{
    void Update()
    {
        if (SetFPS.SIsDebugActived == 0)
        {
            Destroy(gameObject);
        }
    }
}
