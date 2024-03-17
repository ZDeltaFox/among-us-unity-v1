using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Course : MonoBehaviour
{
    public Slider Nav1;
    public Slider Nav2;
    public Slider Nav3;
    public Slider Nav4;
    public Slider Nav5;

    float fNav1;
    float fNav2;
    float fNav3;
    float fNav4;
    float fNav5;

    public GameObject Handler1;
    public GameObject Handler2;
    public GameObject Handler3;
    public GameObject Handler4;
    public GameObject Handler5;

    public AudioSource MissionClear;

    void Start()
    {
        MissionClear.GetComponent<AudioSource>();
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;

        Handler1.SetActive(true);
        Nav1.enabled = true;
        Handler2.SetActive(false);
        Nav2.enabled = false;
        Handler3.SetActive(false);
        Nav3.enabled = false;
        Handler4.SetActive(false);
        Nav4.enabled = false;
        Handler5.SetActive(false);
        Nav5.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Finished) {Destroy(gameObject);}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        if (fNav1 == 100) {Handler1.SetActive(false); Handler2.SetActive(true); Nav1.enabled = false; Nav2.enabled = true;}
        if (fNav2 == 100) {Handler2.SetActive(false); Handler3.SetActive(true); Nav2.enabled = false; Nav3.enabled = true;}
        if (fNav3 == 100) {Handler3.SetActive(false); Handler4.SetActive(true); Nav3.enabled = false; Nav4.enabled = true;}
        if (fNav4 == 100) {Handler4.SetActive(false); Handler5.SetActive(true); Nav4.enabled = false; Nav5.enabled = true;}
        if (fNav5 == 100) {Nav5.enabled = false; StartCoroutine(DestroyGO());}
    }
    public void Nav1Slider(float valor) {fNav1 = Mathf.Round(valor);}
    public void Nav2Slider(float valor) {fNav2 = Mathf.Round(valor);}
    public void Nav3Slider(float valor) {fNav3 = Mathf.Round(valor);}
    public void Nav4Slider(float valor) {fNav4 = Mathf.Round(valor);}
    public void Nav5Slider(float valor) {fNav5 = Mathf.Round(valor);}

    public IEnumerator DestroyGO()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        GameTasksSlider.Position += 7;
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        Finished = true;
    }

    public void Esc()
    {
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }

    public static bool Finished;
}
