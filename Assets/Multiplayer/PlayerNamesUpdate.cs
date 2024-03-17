using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerNamesUpdate : MonoBehaviour
{
    public VerticalLayoutGroup layoutGroup;
    
    void OnEnable() 
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable() 
    {
        layoutGroup.childForceExpandWidth = true;
        layoutGroup.childForceExpandHeight = true;
        yield return new WaitForSeconds(1f);
        layoutGroup.childForceExpandWidth = false;
        layoutGroup.childForceExpandHeight = false;
    }
}
