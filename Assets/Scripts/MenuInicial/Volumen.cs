using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    void Start()
    {
        //slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        //Asignamos el slider para que cambie el volumen
        slider.value = audioSource.volume;
        slider.value = sliderValue;
        //Escucha cambios en el slider para cambiar el volumen
        slider.onValueChanged.AddListener(ChangeSlider);
        RevisarMute();

    }

    public void ChangeSlider(float value)
    {
        audioSource.volume = value;
        //sliderValue = value;
        //PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        RevisarMute();

    }

    public void RevisarMute()
    {
        //Si el valor del slider esta en 0 salta una imagen de mute
        if (slider.value == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
}
