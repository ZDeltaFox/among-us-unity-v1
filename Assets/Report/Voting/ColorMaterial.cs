using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorMaterial : MonoBehaviour
{
    public CanvasRenderer sr1;
    public Material m1;

    void Start()
    {
        
    }

    void Update()
    {
        sr1.SetColor(m1.color);
    }
}
