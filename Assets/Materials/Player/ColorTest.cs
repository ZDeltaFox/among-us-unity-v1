using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour
{
    public Material material1;
    public Material material2;


    // Update is called once per frame
    public void Test()
    {
        material1.color = material2.color;
    }
}
