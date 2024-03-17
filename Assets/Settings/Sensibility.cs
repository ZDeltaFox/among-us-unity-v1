using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sensibility : MonoBehaviour
{
    public Slider SensibilitySlider;

    public float AjustesDeSensibilidad;

    public TMP_Text SensibilityText;

    void Start()
    {
        SensibilitySlider.value = PlayerPrefs.GetFloat("Sensibilidad");
    }

    public void ChangeSlider(float valor)
    {
        AjustesDeSensibilidad = valor;
        PlayerPrefs.SetFloat("Sensibilidad", AjustesDeSensibilidad);
    }

    void Update()
    {
        SensibilityText.text = (Mathf.Round(AjustesDeSensibilidad / 5)).ToString() + "%";
        SusCam.Sensibility = SensibilitySlider.value;
    }
}
