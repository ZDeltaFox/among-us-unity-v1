using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Username : MonoBehaviour
{
    public static string user;
    public string name;

    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        user = PlayerPrefs.GetString("Username");
    }

    void Update()
    {
        name = user;
    }
}
