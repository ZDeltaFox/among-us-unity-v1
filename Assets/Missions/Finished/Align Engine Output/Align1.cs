using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Align1 : MonoBehaviour
{
    public static bool Finished;

    public Slider AlignEngine;

    float fAlign;
    
    public GameObject AlignGO;

    public AudioSource MissionClear;

    public GameObject Task;

    float fTask;
    public float Objective;

    void Start()
    {
        MissionClear.GetComponent<AudioSource>();
        AlignEngine.value = Random.Range(-50, 50);

        fTask = Random.Range(-50, 50);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
    }

    void Update()
    {
        if (Finished) {Destroy(gameObject);}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        if (fAlign >= fTask - 1 && fAlign <= fTask + 1) {AlignEngine.enabled = false; StartCoroutine(DestroyGO());}

        AlignGO.transform.eulerAngles = new Vector3(0, 0, -fAlign);
        Task.transform.eulerAngles = new Vector3(0, 0, -fTask);

        Objective = fTask;
    }

    public void AlignSlider(float valor) {fAlign = Mathf.Round(valor);}

    public void Esc()
    {
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }

    public IEnumerator DestroyGO()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        Finished = true;
        Destroy(gameObject);
        GameTasksSlider.Position += 7;
    }
}
