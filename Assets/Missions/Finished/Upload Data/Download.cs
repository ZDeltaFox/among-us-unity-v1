using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Download : MonoBehaviour
{
    public static bool Finished;

    float timer;
    float rTime = 3f;
    float roundTime;
    float timeLeft;
    float downloadTime = 2f;
    float downloading;

    public TMP_Text tDownloading;
    public TMP_Text tTime;

    public Image downloadI;

    bool isDownloading;

    public Button downloadButtonGO;

    void Update()
    {
        if (Finished) {Destroy(gameObject);}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        downloadI.fillAmount = downloading / 21;
        downloading = Mathf.Round(timer / 1);
        roundTime = Mathf.Round(timer);

        if (isDownloading)
        {
            timer += Time.deltaTime;
            downloadTime += Time.deltaTime;
            rTime += Time.deltaTime;

            if (downloadTime >= 2)
            {
                downloading = Random.Range(0, 29);
                downloadTime = 0;
            }

            if (rTime >= 3)
            {
                if (timer <= 7)
                {
                    timeLeft = Random.Range(0, 2);
                    if (timeLeft == 0) {tTime.text = Random.Range(2, 99) + " years left";}
                    if (timeLeft == 1) {tTime.text = Random.Range(2, 12) + " months left";}
                    if (timeLeft == 2) {tTime.text = Random.Range(2, 4) + " weeks left";}
                } 

                if (timer >= 7 && timer <= 13)
                {
                    timeLeft = Random.Range(0, 2);
                    if (timeLeft == 0) {tTime.text = Random.Range(2, 7) + " days left";}
                    if (timeLeft == 1) {tTime.text = Random.Range(2, 24) + " hours left";}
                    if (timeLeft == 2) {tTime.text = Random.Range(2, 60) + " minutes left";}
                } 

                if (timer >= 13 && timer <= 17)
                {
                    timeLeft = Random.Range(0, 1);
                    if (timeLeft == 0) {tTime.text = Random.Range(2, 60) + " minutes left";}
                    if (timeLeft == 1) {tTime.text = Random.Range(2, 60) + " seconds left";}
                } 
                rTime = 0;
            }

            if (roundTime == 18) {tTime.text = "3 seconds left";}
            if (roundTime == 19) {tTime.text = "2 seconds left";}
            if (roundTime == 20) {tTime.text = "1 second left";}
            if (roundTime == 21) {tTime.text = "Complete"; StartCoroutine(DestroyGO()); isDownloading = false; downloadButtonGO.interactable = false;}
        }

        if (downloading == 0) {tDownloading.text = "";}
        if (downloading == 1) {tDownloading.text = "Downloading: Pov_Tr0yan_32B_H4ck.dll";}
        if (downloading == 2) {tDownloading.text = "Downloading: XXX+18VideosXXX Premium Unblocked.exe";}
        if (downloading == 3) {tDownloading.text = "Downloading: TLauncher.exe";}
        if (downloading == 4) {tDownloading.text = "Downloading: Minecraft PE Pirateado FULL 100% CRACKED.exe";}
        if (downloading == 5) {tDownloading.text = "Downloading: YouTube.exe";}
        if (downloading == 6) {tDownloading.text = "Downloading: Among UwUs 3D.exe";}
        if (downloading == 7) {tDownloading.text = "Downloading: Fur Guys by: Z-Dev (No copiado de Aguineu).apk";}
        if (downloading == 8) {tDownloading.text = "Downloading: Que es un shader Alva Majo.mp4";}
        if (downloading == 9) {tDownloading.text = "Downloading: Among Us Unity Tutorial.html";}
        if (downloading == 10) {tDownloading.text = "Downloading: G.exe";}
        if (downloading == 11) {tDownloading.text = "Downloading: Dodging Blocks (Dinax Games) CRACK by: ElAmigos.exe";}
        if (downloading == 12) {tDownloading.text = "Downloading: Opera GX.exe";}
        if (downloading == 13) {tDownloading.text = "Downloading: Shingeki_no_Kyojin_Cap13_T2_144p.mp4";}
        if (downloading == 14) {tDownloading.text = "Downloading: Capybaras Mod.mcaddon";}
        if (downloading == 15) {tDownloading.text = "Downloading: Aguineu_peluche.blend";}
        if (downloading == 16) {tDownloading.text = "Downloading: OptiFine_1.19.2_HD_U_H9.jar";}
        if (downloading == 17) {tDownloading.text = "Downloading: Exercicis_de_matematiques_16_12_2022.png";}
        if (downloading == 18) {tDownloading.text = "Downloading: Instale Windows 11 en una PC del gobierno.html";}
        if (downloading == 19) {tDownloading.text = "Downloading: Windows 12.iso";}
        if (downloading == 20) {tDownloading.text = "Downloading: FNaF Cutre.apk";}
        if (downloading == 21) {tDownloading.text = "Downloading: Suscribete.mp4";}
        if (downloading == 22) {tDownloading.text = "Downloading: Kahoot H4cks.apk";}
        if (downloading == 23) {tDownloading.text = "Downloading: Guille Clicker.apk";}
        if (downloading == 24) {tDownloading.text = "Downloading: Cruchyroll_premium.apk";}
        if (downloading == 25) {tDownloading.text = "Downloading: Geometry Dash Todo Desbloqueado.apk";}
        if (downloading == 26) {tDownloading.text = "Downloading: Minecraft Aristois H4ck3d client.jar";}
        if (downloading == 27) {tDownloading.text = "Downloading: Como ser pro en Minecraft.html";}
        if (downloading == 28) {tDownloading.text = "Downloading: Como conseguir que ella te ame.html";}
        if (downloading == 29) {tDownloading.text = "Downloading: Porque nadie me quiere.html";}
    }

    public AudioSource MissionClear;

    void Start()
    {
        MissionClear.GetComponent<AudioSource>();
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
    }

    public void DownloadButton()
    {
        isDownloading = !isDownloading;
    }

    private IEnumerator DestroyGO()
    {
        GameTasksSlider.Position += 7;
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        Finished = true;
        Destroy(gameObject);
    }

    public void Esc()
    {
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }
}
