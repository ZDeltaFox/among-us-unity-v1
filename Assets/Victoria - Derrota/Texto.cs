using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Texto : MonoBehaviour
{
    public TMP_Text Victory;

    void Start()
    {
        
    }

    void Update()
    {
        Victory.text = PlayersAlive.sFinalText;
    }
}
