using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class soundSettings : MonoBehaviour
{

    [SerializeField] public GameObject SoundPanelSettings;

    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider SoundtrackSlider;



    void Start()
    {
        //miramos si ya hay algun valor guardado para los sliders
        if (PlayerPrefs.HasKey("masterVol"))
        {
            LoadMaster();
        }
        else { SetMasterVolume(); }
        if (PlayerPrefs.HasKey("sfxVol"))
        {
            LoadSFX();
        }
        else { SetSFXVolume(); }

        if (PlayerPrefs.HasKey("soundtrackVol"))
        {
            LoadSoundtrack();
        }
        else { SetSoundtrackVolume(); }

    }

    //cargamos los valores si los hay
    public void LoadMaster()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("masterVol");
        SetMasterVolume();
    }
    public void LoadSFX()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("sfxVol");
        SetSFXVolume();
    }

    public void LoadSoundtrack()
    {
        SoundtrackSlider.value = PlayerPrefs.GetFloat("soundtrackVol");
        SetSoundtrackVolume();
    }


    //asignamos valores con los sliders
    public void SetMasterVolume()
    {
        float volume = MasterSlider.value;
        Mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVol", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        Mixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVol", volume);
    }
    public void SetSoundtrackVolume()
    {
        float volume = SoundtrackSlider.value;
        Mixer.SetFloat("SoundtrackVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("soundtrackVol", volume);
    }





    public void ActivateSoundPanel()
    {
        if (SoundPanelSettings.activeSelf) //objeto activo
        {
            SoundPanelSettings.SetActive(false);
        }
        else
        {
            SoundPanelSettings.SetActive(true);
        }

    }
}
