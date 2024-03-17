using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Garbage
{
public class EmptyGarbage1 : MonoBehaviour
{
    //[HideInInspector]
    public Slider Throw;

    public GameObject Floor;

    public AudioSource MissionClear;

    float fThrow;

    void Start()
    {
        MissionClear.GetComponent<AudioSource>();
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fThrow == 100) {Throw.enabled = false; StartCoroutine(DestroyGO()); fThrow = 0;}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }
        if (Finished) {Destroy(gameObject);}
    }

    public void ThrowSlider(float valor) {fThrow = Mathf.Round(valor);}
    public IEnumerator DestroyGO()
    {
        Destroy(Floor);
        MissionClear.Play();
        yield return new WaitForSeconds(3f);
        GameTasksSlider.Position += 7;
        Finished = true;
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }

    public void Esc()
    {
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }

    public static bool Finished;
}
}
