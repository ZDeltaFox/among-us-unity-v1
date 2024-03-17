using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveDeathCam : MonoBehaviour
{
    public GameObject DeathCam;

    void Update()
    {
        if (MultiplayerPlayerController.SusPlayerMovement.isSDeath)
        {
            DeathCam.SetActive(true);
        }

        else
        {
            DeathCam.SetActive(false);
        }
    }
}
