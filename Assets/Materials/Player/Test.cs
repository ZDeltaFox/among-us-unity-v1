using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    private void OnMouseEnter() 
    {
        transform.position += new Vector3 (0, 1000, 0);
    }

    private void OnMouseExit() 
    {
        transform.position -= new Vector3 (0, 1000, 0);
    }
}
