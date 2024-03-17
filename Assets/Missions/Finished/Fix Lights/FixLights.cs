using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixLights : MonoBehaviour
{
    public static float sPoints;
    public float Points;

    public GameObject Up;
    public GameObject On;
    public GameObject Down;
    public GameObject Off;

    public bool isOn;
    public bool isUp;

    public AudioSource MissionClear;
    public GameObject Root;

    public static bool Finished;
    bool isActived;
    public static bool sIsActived;

    void Update() 
    {
        sIsActived = isActived; 

        if (isUp)
        {
            Up.SetActive(true);
            Down.SetActive(false);
        }

        else
        {
            Up.SetActive(false);
            Down.SetActive(true);
        }

        if (isOn)
        {
            On.SetActive(true);
            Off.SetActive(false);
        }

        else
        {
            On.SetActive(false);
            Off.SetActive(true);
        }

        Points = sPoints;

        if (Points == 5)
        {
            Sabotage.sXLights = 0;
            StartCoroutine(Destroy());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(Root);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }
        if (Finished) {Destroy(Root);}
    }

    public void Click()
    {
        isOn = !isOn;
        isUp = !isUp;

        if (isOn) {sPoints++;}
        else {sPoints--;}
    }

    public void Start()
    {
        isActived = false;
        MissionClear = GetComponent<AudioSource>();
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
        sPoints = 0;
        Finished = false;
    }

    public IEnumerator Destroy()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        Finished = true;
        Destroy(Root);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        isActived = true;
        sIsActived = true;
    }

    public void Quit()
    {
        Destroy(Root);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }
}
