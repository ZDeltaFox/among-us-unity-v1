using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    public bool useCustomParent = true;
    public string customParentName;

    private void Awake()
    {
        if (useCustomParent)
        {
            GameObject customParent = GameObject.Find(customParentName);
            if (customParent != null)
            {
                transform.SetParent(customParent.transform);
            }
            else
            {
                Debug.LogError("Custom parent object not found: " + customParentName);
            }
        }
    }
}
