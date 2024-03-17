using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSabotage : MonoBehaviour
{
    [Header ("Lights")]
    public GameObject Lights;

    [Header ("O₂")]
    public GameObject o2r1;
    public GameObject o2r2;

    void Update()
    {
        if (Sabotage.sXLights == 1) {Lights.SetActive(true);}
        else {Lights.SetActive(false);}


        if (Sabotage.sXO2r1 == 1) {o2r1.SetActive(true);}
        else {o2r1.SetActive(false);}

        if (Sabotage.sXO2r2 == 1) {o2r2.SetActive(true);}
        else {o2r2.SetActive(false);}
    }
}
