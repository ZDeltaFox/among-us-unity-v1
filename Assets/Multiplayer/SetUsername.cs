using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SetUsername : MonoBehaviour
{
    public TMP_InputField _username;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            _username.text = PlayerPrefs.GetString("Username");
        }

        else
        {
            _username.text = "Player" + Random.Range(0000,9999).ToString("0000");
            PlayerPrefs.SetString("Username", _username.text);
        }
    }

    public void ChangeName()
    {
        PlayerPrefs.SetString("Username", _username.text);
    }
}
