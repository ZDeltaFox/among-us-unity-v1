using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetFPS : MonoBehaviour
{
    public int FPS;

    public string Limit;

    public TMP_Text FPSText;

    //FPS Controller
    public GameObject fpsMinus;
    public GameObject fpsPlus;

    //Reached limit
    public GameObject rfpsMin;
    public GameObject rfpsMax;

    public float isDebugActived = 0;
    public static float SIsDebugActived;

    public GameObject DebugMode;

    void Start()
    {
        Application.targetFrameRate = 60;
        FPS = PlayerPrefs.GetInt("fpsvalue", 0);
        Application.targetFrameRate = FPS;
        isDebugActived = PlayerPrefs.GetFloat("Debugging");
        Instantiate(DebugMode);
    }

    void Update()
    {
        //Debug
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (Input.GetKey("left ctrl"))
            {
                if (isDebugActived == 0)
                {
                    Instantiate(DebugMode);
                    isDebugActived = 1;
                    Debug.Log("isDebugActived = true");
                }

                else
                {
                    isDebugActived = 0;
                    Debug.Log("isDebugActived = false");
                }

                PlayerPrefs.SetFloat("Debugging", isDebugActived);
            }
        }

        SIsDebugActived = isDebugActived;

        PlayerPrefs.SetInt("fpsvalue", FPS);

        FPS = Application.targetFrameRate;

        if (FPS == 0)
        {
            Application.targetFrameRate = 24;
        }

        if (FPS >= 0)
        {
            FPSText.text = FPS.ToString("00") + " FPS";
        }
        else
        {
            FPSText.text = Limit;
        }

        if (FPS == 1)
        {
            fpsMinus.SetActive(false);
            rfpsMin.SetActive(true);
        }
        else
        {
            fpsMinus.SetActive(true);
            rfpsMin.SetActive(false);
        }

        if (FPS == -1)
        {
            fpsPlus.SetActive(false);
            rfpsMax.SetActive(true);
        }
        else
        {
            fpsPlus.SetActive(true);
            rfpsMax.SetActive(false);
        }

        if (isDebugActived == 0)
        {
            if (FPS <= 23)
            {
                if (FPS >= 0)
                {
                    Application.targetFrameRate = 24;
                }
            }
        }
    }

    public void FPSMinus()
    {
        if (FPS == -1)
        {
            Application.targetFrameRate = 144;
        }

        if (FPS == 144)
        {
            Application.targetFrameRate = 120;
        }
        
        if (FPS == 120)
        {
            Application.targetFrameRate = 90;
        }

        if (FPS == 90)
        {
            Application.targetFrameRate = 60;
        }

        if (FPS == 60)
        {
            Application.targetFrameRate = 30;
        }

        if (FPS == 30)
        {
            Application.targetFrameRate = 24;
        }
#region Debug
        if (isDebugActived == 1)
        {
            if (FPS == 24)
            {
                Application.targetFrameRate = 20;
            }

            if (FPS == 20)
            {
                Application.targetFrameRate = 15;
            }

            if (FPS == 15)
            {
                Application.targetFrameRate = 10;
            }

            if (FPS == 10)
            {
                Application.targetFrameRate = 5;
            }

            if (FPS == 5)
            {
                Application.targetFrameRate = 1;
            }
        }
#endregion
    }

    public void FPSPlus()
    {
        if (FPS == 144)
        {
            Application.targetFrameRate = -1;
        }

        if (FPS == 120)
        {
            Application.targetFrameRate = 144;
        }
        
        if (FPS == 90)
        {
            Application.targetFrameRate = 120;
        }

        if (FPS == 60)
        {
            Application.targetFrameRate = 90;
        }

        if (FPS == 30)
        {
            Application.targetFrameRate = 60;
        }

        if (FPS == 24)
        {
            Application.targetFrameRate = 30;
        }
#region Debug
        if (isDebugActived == 1)
        {
            if (FPS == 1)
            {
                Application.targetFrameRate = 5;
            }

            if (FPS == 5)
            {
                Application.targetFrameRate = 10;
            }

            if (FPS == 10)
            {
                Application.targetFrameRate = 15;
            }

            if (FPS == 15)
            {
                Application.targetFrameRate = 20;
            }

            if (FPS == 20)
            {
                Application.targetFrameRate = 24;
            }
        }
#endregion
    }
}