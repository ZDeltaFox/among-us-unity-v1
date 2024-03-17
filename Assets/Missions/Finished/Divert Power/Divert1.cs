using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Divert1 : MonoBehaviour
{
    [Header ("Audio")]
    public AudioSource MissionClear;

    //60-70
    [HideInInspector]
    public Slider rEngine;
    [Header ("Right Engine")]
    public float frEngine;
    [HideInInspector]
    public bool REngineActivated;

    //35-45
    [HideInInspector]
    public Slider lEngine;
    [Header ("Left Engine")]
    public float flEngine;
    [HideInInspector]
    public bool LEngineActivated;

    //85-95
    [HideInInspector]
    public Slider Weapons;
    [Header ("Weapons")]
    public float fWeapons;
    [HideInInspector]
    public bool WeaponsActivated;

    //39-41
    [HideInInspector]
    public Slider Shields;
    [Header ("Shields")]
    public float fShields;
    [HideInInspector]
    public bool ShieldsActivated;

    //84-86
    [HideInInspector]
    public Slider Nav;
    [Header ("Navigation")]
    public float fNav;
    [HideInInspector]
    public bool NavActivated;

    //59-61
    [HideInInspector]
    public Slider Comms;
    [Header ("Comunications")]
    public float fComms;
    [HideInInspector]
    public bool CommsActivated;

    //34-36
    [HideInInspector]
    public Slider O2;
    [Header ("O₂")]
    public float fO2;
    [HideInInspector]
    public bool O2Activated;

    //44-46
    [HideInInspector]
    public Slider Security;
    [Header ("Security")]
    public float fSecurity;
    [HideInInspector]
    public bool SecurityActivated;

    void Start()
    {
        rEngine.value = Random.Range(0, 100);
        lEngine.value = Random.Range(0, 100);
        Weapons.value = Random.Range(0, 100);
        Shields.value = Random.Range(0, 100);
        Nav.value = Random.Range(0, 100);
        Comms.value = Random.Range(0, 100);
        O2.value = Random.Range(0, 100);
        Security.value = Random.Range(0, 100);

        MissionClear = GetComponent<AudioSource>();

        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
    }

    void Update()
    {
        if (frEngine >= 64 && frEngine <= 68) {REngineActivated = true; rEngine.enabled = false;}
        else {rEngine.enabled = true;}
        if (flEngine >= 39 && flEngine <= 41) {LEngineActivated = true; lEngine.enabled = false;}
        else {lEngine.enabled = true;}
        if (fWeapons >= 89 && fWeapons <= 91) {WeaponsActivated = true; Weapons.enabled = false;}
        else {Weapons.enabled = true;}
        if (fShields >= 39 && fShields <= 41) {ShieldsActivated = true; Shields.enabled = false;}
        else {Shields.enabled = true;}
        if (fNav >= 84 && fNav <= 86) {NavActivated = true; Nav.enabled = false;}
        else {Nav.enabled = true;}
        if (fComms >= 59 && fComms <= 61) {CommsActivated = true; Comms.enabled = false;}
        else {Comms.enabled = true;}
        if (fO2 >= 34 && fO2 <= 36) {O2Activated = true; O2.enabled = false;}
        else {O2.enabled = true;}
        if (fSecurity >= 44 && fSecurity <= 46) {SecurityActivated = true; Security.enabled = false;}
        else {Security.enabled = true;}

        if (REngineActivated && LEngineActivated && WeaponsActivated && ShieldsActivated && NavActivated && CommsActivated && O2Activated && SecurityActivated) 
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

    public void rEngineSlider(float valor) {frEngine = Mathf.Round(valor);}
    public void lEngineSlider(float valor) {flEngine = Mathf.Round(valor);}
    public void WeaponsSlider(float valor) {fWeapons = Mathf.Round(valor);}
    public void ShieldsSlider(float valor) {fShields = Mathf.Round(valor);}
    public void NavSlider(float valor) {fNav = Mathf.Round(valor);}
    public void CommsSlider(float valor) {fComms = Mathf.Round(valor);}
    public void O2Slider(float valor) {fO2 = Mathf.Round(valor);}
    public void SecuritySlider(float valor) {fSecurity = Mathf.Round(valor);}

    private IEnumerator DestroyGO()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        GameTasksSlider.Position += 3;
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
