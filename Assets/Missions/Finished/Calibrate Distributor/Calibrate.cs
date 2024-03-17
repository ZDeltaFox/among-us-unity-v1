using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrate : MonoBehaviour
{
    [HideInInspector]
    public GameObject Q;
    [Header ("Actual Rotation")]
    public float currentRotZ1;
    [HideInInspector]
    public GameObject QL;
    [HideInInspector]
    public GameObject W;
    public float currentRotZ2;
    [HideInInspector]
    public GameObject WL;
    [HideInInspector]
    public GameObject E;
    public float currentRotZ3;
    [HideInInspector]
    public GameObject EL;

    [Header ("Rotation Velocity")]
    public float Distribuitor1;
    public float Distribuitor2;
    public float Distribuitor3;

    bool isQActivated;
    bool isWActivated;
    bool isEActivated;

    [Header ("Points")]
    public float Points;

    public AudioSource MissionClear;
    public static bool Finished;

    void Start()
    {
        isQActivated = true;
        isWActivated = true;
        isEActivated = true;

        Points = 0;

        MissionClear.GetComponent<AudioSource>();
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
    }

    void Update()
    {
        if (isQActivated) Q.transform.eulerAngles += new Vector3(0, 0, Distribuitor1);
        currentRotZ1 = Mathf.Round(Q.transform.eulerAngles.z);
        QL.SetActive(!isQActivated);

        if (isWActivated) W.transform.eulerAngles += new Vector3(0, 0, Distribuitor2);
        currentRotZ2 = Mathf.Round(W.transform.eulerAngles.z);
        WL.SetActive(!isWActivated);

        if (isEActivated) E.transform.eulerAngles += new Vector3(0, 0, Distribuitor3);
        currentRotZ3 = Mathf.Round(E.transform.eulerAngles.z);
        EL.SetActive(!isEActivated);

        if (isQActivated && isWActivated && isEActivated) {Points = 0;}
        if (!isQActivated && isWActivated && isEActivated || !isWActivated && isQActivated && isEActivated || !isEActivated && isWActivated && isQActivated) {Points = 1;}
        if (!isQActivated && !isWActivated && isEActivated || isQActivated && !isWActivated && !isEActivated || !isQActivated && isWActivated && !isEActivated) {Points = 2;}
        if (!isQActivated && !isWActivated && !isEActivated) {Points = 3;}

        if (Points == 3)
        {
            StartCoroutine(DestroyGO());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        if (Finished) {Destroy(gameObject);}
    }

    public void isQClicked()
    {
        if (currentRotZ1 >= 160 && currentRotZ1 <= 200) {isQActivated = false;}
    }

    public void isWClicked()
    {
        if (currentRotZ2 >= 160 && currentRotZ2 <= 200) {isWActivated = false;}
    }

    public void isEClicked()
    {
        if (currentRotZ3 >= 160 && currentRotZ3 <= 200) {isEActivated = false;}
    }

    public IEnumerator DestroyGO()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        Finished = true;
        GameTasksSlider.Position += 7;
    }

    public void Esc()
    {
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }
}
