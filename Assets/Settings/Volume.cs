using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Volume : MonoBehaviour
{
    public Slider Volumen;

    public float AjustesDeVolumen;

    public TMP_Text MusicText;

    void Start()
    {
        Volumen.value = PlayerPrefs.GetFloat("Ajustes");
        AudioListener.volume = Volumen.value;
    }

    public void ChangeSlider(float valor)
    {
        AjustesDeVolumen = valor;
        PlayerPrefs.SetFloat("Ajustes", AjustesDeVolumen);
        AudioListener.volume = Volumen.value;
    }

    void Update()
    {
        MusicText.text = (Mathf.Round(AjustesDeVolumen * 100)).ToString() + "%";
    }
}

