using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnAsteroids : MonoBehaviour
{
    public static bool Destroy;
    public int Points;
    public static int sPoints;
    float RandomObject;

    public static bool Finished;

    public GameObject A1;
    public GameObject A2;
    public GameObject A3;
    public GameObject A4;
    public GameObject A5;

    public float timer;
    float maxTime = 0.2f;

    float SpawnX1;
    float SpawnX2;
    float SpawnY;

    public TMP_Text TotalPoints;

    void Update()
    {
        if (Finished) {Destroy(gameObject);}
        timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            StartCoroutine(Randomizer());
            timer = 0;
        }

        Points = sPoints;

        if (Points <= 20)
        {
            TotalPoints.text = "Puntos: " + Points + " / 20";
        }        

        if (Points >= 20 && Points <= 30) 
        {
            Points = 50;
            Destroy = true;
            StartCoroutine(DestroyGO());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            Destroy = true;
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }
    }

    void Start()
    {
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
        sPoints = 0;
        Destroy = false;
        MissionClear.GetComponent<AudioSource>();
    }

    IEnumerator Randomizer()
    {
        SpawnX1 = Random.Range(-340, -240);
        SpawnX2 = Random.Range(240, 340);
        SpawnY = Random.Range(160, 60);
        RandomObject = Random.Range(1, 5);
        yield return new WaitForSeconds(0.1f);
        if (RandomObject == 1) {Instantiate(A1);}
        if (RandomObject == 2) {Instantiate(A2);}
        if (RandomObject == 3) {Instantiate(A3);}
        if (RandomObject == 4) {Instantiate(A4);}
        if (RandomObject == 5) {Instantiate(A5);}
    }

    public IEnumerator DestroyGO()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Finished = true;
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        GameTasksSlider.Position += 7;
    }

    public void Quit()
    {
        Destroy(gameObject);
        Destroy = true;
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }

    public AudioSource MissionClear;
}
