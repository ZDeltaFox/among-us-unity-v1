using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    [Header ("Code")]
    public TMP_Text cardCode;

    [Header ("Enter")]
    public TMP_Text inputCode;
    public int ENumber;
    public int CodeLength = 5;

    [Header ("Options")]
    public float CodeResetTime = 0.5f;

    private bool isResetting = false;
    public AudioSource MissionClear;
    public AudioSource Error;

    void Start()
    {
        isActived = false;

        MissionClear.GetComponent<AudioSource>();
        Error.GetComponent<AudioSource>();
        string code = string.Empty;

        for (int i = 0; i < CodeLength; i++)
        {
            code += Random.Range(0, 9);
        }

        cardCode.text = code;
        inputCode.text = string.Empty;

        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
    }

    void Update()
    {

        if (Sabotage.sXO2r1 == 0) {Destroy(gameObject);}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        sIsActived = isActived; 
    }

    public void Button(int Button) 
    {
        if (isResetting) {return;}
        inputCode.text += Button;

        if (inputCode.text == cardCode.text)
        {
            inputCode.text = "OK";
            StartCoroutine(OKCode());
        }

        else if (inputCode.text.Length >= CodeLength)
        {
            inputCode.text = "INCORRECTO";
            StartCoroutine(ResetCode());
        }
    }

    bool isActived;
    public static bool sIsActived;

    private IEnumerator OKCode()
    {
        isResetting = true;
        MissionClear.Play();

        yield return new WaitForSeconds(CodeResetTime * 2);
        inputCode.text = string.Empty;
        isResetting = false;
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        isActived = true;
        sIsActived = true;
        Destroy(gameObject);
    }


    private IEnumerator ResetCode()
    {
        isResetting = true;
        Error.Play();

        yield return new WaitForSeconds(CodeResetTime);
        inputCode.text = string.Empty;
        isResetting = false;
    }

    public void Confirm()
    {
        inputCode.text = "INCORRECTO";
        StartCoroutine(ResetCode());
    }

    public void ResetButton()
    {
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        isResetting = true;
        yield return new WaitForSeconds(0);
        inputCode.text = string.Empty;
        isResetting = false;
    }

    public void Quit()
    {
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }
}
