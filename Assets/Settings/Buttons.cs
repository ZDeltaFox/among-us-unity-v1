using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [Header ("Menus")]
    public GameObject MainMenu;
    public GameObject LobbyMenu;
    public GameObject LobbyLoadMenu;
    public GameObject SettingsMenu;
    public GameObject InfoMenu;
    public GameObject CustomMenu;
    public GameObject KeysMenu;
    public GameObject AmongUsText;

    [Header ("Carga")]
    public static bool isInLoad;
    public bool isLoading;

    [Header ("Temporizador")]
    public static float stimer;
    public float timer;
    public static float smaxTime;
    public float maxTime = 15f;

    [Header ("Audio")]
    public AudioSource Button;

    void Start()
    {
        MainMenu.SetActive(true);
        LobbyMenu.SetActive(false);
        LobbyLoadMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(false);
        CustomMenu.SetActive(false);
        AmongUsText.SetActive(true);

        isInLoad = false;

        Button.GetComponent<AudioSource>();

        chatActived = false;
    }

    public void Return()
    {
        MainMenu.SetActive(true);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(false);
        AmongUsText.SetActive(true);
        CustomMenu.SetActive(false);

        Button.Play();

        chatActived = false;
    }

    public void Settings()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(false);
        AmongUsText.SetActive(true);

        Button.Play();

        chatActived = false;
    }

    public void Customize()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(false);
        CustomMenu.SetActive(true);
    }

    public void Keys()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(true);
        AmongUsText.SetActive(false);

        Button.Play();

        chatActived = false;
    }

    public void Lobby()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        AmongUsText.SetActive(true);

        Button.Play();

        chatActived = false;
    }

    public void Info()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(true);
        KeysMenu.SetActive(false);
        AmongUsText.SetActive(true);

        Button.Play();

        chatActived = false;
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        chatActived = false;
    }

    public void Quit()
    {
        Application.Quit();

        Button.Play();

        chatActived = false;
    }

    public static bool chatActived;

    public void Chat()
    {
        chatActived = true;
    }

    void Update()
    {
        isLoading = isInLoad;

        if (isInLoad)
        {
            MainMenu.SetActive(false);
            LobbyMenu.SetActive(false);
            LobbyLoadMenu.SetActive(true);
            SettingsMenu.SetActive(false);
            KeysMenu.SetActive(false);
            AmongUsText.SetActive(true);

            stimer += Time.deltaTime;
        }

        else {stimer = 0;}

        timer = stimer;
        smaxTime = maxTime;
    }
}
