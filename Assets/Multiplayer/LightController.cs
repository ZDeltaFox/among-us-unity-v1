using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject normalLights;
    public GameObject noLights;
    public GameObject crisisLights;

    bool nL;
    bool cL;

    float timer;

    void Start()
    {
        nL = true;
        timer = 0;
    }

    void Update()
    {
        if (Sabotage.sXLights == 1) {nL = false;}
        else {nL = true;}
        if (Sabotage.sXO2r1 == 0 && Sabotage.sXO2r2 == 0)
        {
            normalLights.SetActive(nL);
            noLights.SetActive(!nL);
        }
        

        if (Sabotage.sXO2r1 == 1 || Sabotage.sXO2r2 == 1)
        {
            noLights.SetActive(false);

            timer += Time.deltaTime;
            if (timer >= 2) {timer = 0;}
            if (timer >= 0.5 && timer <= 1)
            {
                normalLights.SetActive(false);
                crisisLights.SetActive(true);
            }

            else
            {
                normalLights.SetActive(true);
                crisisLights.SetActive(false);
            }
        }

        else
        {
            if (timer != 0) {StartCoroutine(LightReset());}
        }
    }

    private IEnumerator LightReset()
    {
        yield return new WaitForSeconds(0.1f);
        timer = 0;
        normalLights.SetActive(true);
        crisisLights.SetActive(false);
    }
}
