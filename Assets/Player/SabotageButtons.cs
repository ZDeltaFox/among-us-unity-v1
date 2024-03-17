using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SabotageButtons : MonoBehaviour
{
    public TMP_Text O2;
    public TMP_Text Lights;
    float sabotageTime;
    float rSabotageTime;
    bool activeLights;
    bool activeO2;

    public static bool sActiveLights;
    public static bool sActiveO2;

    public Button Light2B;
    public Button O2B;

    void Start()
    {
        sabotageTime = 30;
    }

    void Update()
    {
        if (Sabotage.sXLights == 0 && Sabotage.sXO2r1 == 0 && Sabotage.sXO2r2 == 0) {sabotageTime -= Time.deltaTime;}
        else {sabotageTime = 45;}
        rSabotageTime = Mathf.Round(sabotageTime);

        if (sabotageTime <= 0)
        {
            Lights.text = "";
            O2.text = "";
            Light2B.interactable = true;
            O2B.interactable = true;
        } 

        else if (Sabotage.sXLights == 1 || Sabotage.sXO2r1 == 1 || Sabotage.sXO2r2 == 1)
        {
            Lights.text = "";
            O2.text = "";
            Light2B.interactable = false;
            O2B.interactable = false;
        }

        else
        {
            Lights.text = rSabotageTime.ToString("0");
            O2.text = rSabotageTime.ToString("0");
            Light2B.interactable = false;
            O2B.interactable = false;
        }

        sActiveLights = activeLights;
        sActiveO2 = activeO2;
    }

    public void LightActiveButton()
    {
        activeLights = true;
        StartCoroutine(SetFalse());
    }

    public void O2ActiveButton()
    {
        activeO2 = true;
        StartCoroutine(SetFalse());
    }

    private IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(0.2f);
        activeLights = false;
        activeO2 = false;
    }
}
