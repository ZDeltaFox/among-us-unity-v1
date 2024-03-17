using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class O2Time : MonoBehaviour
{
    public GameObject txt;
    public TMP_Text O2Text;

    float O2Timer;

    float ActivedOxigen;
    void Start()
    {
        O2Timer = 45;
    }

    void Update()
    {
        if (Sabotage.sXO2r1 == 1 || Sabotage.sXO2r2 == 1)
        {
            O2Text.text = "El oxigeno se acaba en " + O2Timer.ToString("0") + " segundos (" + ActivedOxigen.ToString("0") + "/2)";
            txt.SetActive(true);
            O2Timer -= Time.deltaTime;
        }

        else
        {
            O2Timer = 45;
            txt.SetActive(false);
        }

        if (Sabotage.sXO2r1 == 0 && Sabotage.sXO2r2 == 1 || Sabotage.sXO2r1 == 1 && Sabotage.sXO2r2 == 0)
        {
            ActivedOxigen = 1;
        }
    }
}
