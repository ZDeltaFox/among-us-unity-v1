using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButtons : MonoBehaviour
{
    [HideInInspector]
    public Button Button1;
    [HideInInspector]
    public Button Button2;
    [HideInInspector]
    public Button Button3;
    [HideInInspector]
    public Button Button4;
    [HideInInspector]
    public Button Button5;
    [HideInInspector]
    public Button Button6;
    [HideInInspector]
    public Button Button7;
    
    float Actived;
    float total;

    [HideInInspector]
    public AudioSource MissionClear;

    public static bool Finished;

    public void Start()
    {
        total = 0;
        MissionClear.GetComponent<AudioSource>();
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
    }

    void Update()
    {
        if (Actived == 1) {Button1.interactable = false;}
        if (Actived == 2) {Button2.interactable = false;}
        if (Actived == 3) {Button3.interactable = false;}
        if (Actived == 4) {Button4.interactable = false;}
        if (Actived == 5) {Button5.interactable = false;}
        if (Actived == 6) {Button6.interactable = false;}
        if (Actived == 7) {Button7.interactable = false;}

        if (Finished) {Destroy(gameObject);}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        if (total == 7) {StartCoroutine(DestroyGO());}
    }

    public void Buttons(float number)
    {
        Actived = number;
        total++;
    }

    private IEnumerator DestroyGO()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        Finished = true;
        Destroy(gameObject);
        GameTasksSlider.Position += 7;
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }

    public void Esc()
    {
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }
}
