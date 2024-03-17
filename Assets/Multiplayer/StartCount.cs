using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCount : MonoBehaviour
{
    void Start()
    {
        GameTasksSlider.Position = 1;
        Destroy(gameObject);
    }
}
