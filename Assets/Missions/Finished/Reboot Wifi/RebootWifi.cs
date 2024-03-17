using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebootWifi : MonoBehaviour
{
    public static bool Finished;

    public Slider Reboot;

    public AudioSource MissionClear;

    float fReboot;

    void Start()
    {
        MissionClear.GetComponent<AudioSource>();
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fReboot == 50) {Reboot.enabled = false; StartCoroutine(DestroyGO());}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        if (Finished) {Destroy(gameObject);}
    }

    public void RebootSlider(float valor) {fReboot = Mathf.Round(valor);}
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
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }
}
