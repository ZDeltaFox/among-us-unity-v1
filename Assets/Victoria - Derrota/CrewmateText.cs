using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrewmateText : MonoBehaviour
{
    public TMP_Text Victory;
    
    void Update()
    {
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
            Victory.text = "Derrota";
        }

        else
        {
            Victory.text = "Victoria";
        }
    }
}
