using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brillo : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBrilloJuego;
    public Image panelBrilloMenuPrincipal;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brilllo", 0.1f);

        panelBrilloJuego.color = new Color(panelBrilloJuego.color.r, panelBrilloJuego.color.g, panelBrilloJuego.color.b, slider.value);
        panelBrilloMenuPrincipal.color = new Color(panelBrilloMenuPrincipal.color.r, panelBrilloMenuPrincipal.color.g, panelBrilloMenuPrincipal.color.b, slider.value);
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;  
        
        PlayerPrefs.SetFloat("brillo", sliderValue);

        panelBrilloJuego.color = new Color(panelBrilloJuego.color.r, panelBrilloJuego.color.g, panelBrilloJuego.color.b, slider.value);
        panelBrilloMenuPrincipal.color = new Color(panelBrilloMenuPrincipal.color.r, panelBrilloMenuPrincipal.color.g, panelBrilloMenuPrincipal.color.b, slider.value);

    }
}
