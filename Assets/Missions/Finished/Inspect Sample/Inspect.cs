using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inspect : MonoBehaviour
{
    public static bool Finished;

    public GameObject Menu;

    float timer = 60f;
    float Seconds;

    public TMP_Text tTime;

    public AudioSource MissionClear;

    bool isMenuActived;
    public static bool isMenuActivedS;
    public static bool isOpen;

    void Start()
    {
        MissionClear.GetComponent<AudioSource>();
        timer = 60f;
        isOpen = true;
        isMenuActivedS = true;
    }

    void Update() 
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActivedS = false;
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        Menu.SetActive(isMenuActived);
        isMenuActived = isMenuActivedS;

        if (timer <= 0)
        {
            if (Input.GetKey("mouse 0"))
            {
                if (isMenuActived)
                {
                    StartCoroutine(DestroyGO());
                }
            }
            
            timer = 0;
        }

        else
        {
            timer -= Time.deltaTime;
            Seconds = Mathf.Round(timer);
            tTime.text = "0:" + Seconds;
        }
    }

    public IEnumerator DestroyGO()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        Finished = true;
        GameTasksSlider.Position += 7;
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        Destroy(gameObject);
    }

    public void Esc()
    {
        isMenuActivedS = false;
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }
}
