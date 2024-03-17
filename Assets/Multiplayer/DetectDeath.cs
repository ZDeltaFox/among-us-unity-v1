using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDeath : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject P5;
    public GameObject P6;
    public GameObject P7;
    public GameObject P8;
    public GameObject P9;
    public GameObject P10;

    void Update()
    {
        if (P1.transform.position.x >= 0.25) {if (DetectImpostor.AllIS1 != 1){MultiplayerPlayerController.SusPlayerMovement.isSDeath = true;}}
    }
}
