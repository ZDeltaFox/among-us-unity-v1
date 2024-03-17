using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabotage : MonoBehaviour
{
    [Header ("Lights")]
    public GameObject Lights;
    public static float sXLights;
    public float XLights;


    [Header ("O₂")]
    public GameObject O2r1;
    public GameObject O2r2;
    public static float sXO2r1;
    public float XO2r1;
    public static float sXO2r2;
    public float XO2r2;

    void Update()
    {
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
            if (SabotageButtons.sActiveLights)
            {
                Lights.transform.position = new Vector3(1, 1000, 0);
            }

            if (SabotageButtons.sActiveO2)
            {
                O2r1.transform.position = new Vector3(1, 1000, 0);
                O2r2.transform.position = new Vector3(1, 1000, 0);
            }
        }
        
        if (FixLights.sIsActived) {Lights.transform.position = new Vector3(0, 1000, 0); FixLights.sIsActived = false;}

        if (KeyPad.sIsActived) {O2r1.transform.position = new Vector3(0, 1000, 0); KeyPad.sIsActived = false;}
        if (KeyPad1.sIsActived) {O2r2.transform.position = new Vector3(0, 1000, 0); KeyPad1.sIsActived = false;}

        XLights = Lights.transform.position.x;
        XO2r1 = O2r1.transform.position.x;
        XO2r2 = O2r2.transform.position.x;

        sXLights = XLights;
        sXO2r1 = XO2r1;
        sXO2r2 = XO2r2;
    }
}
