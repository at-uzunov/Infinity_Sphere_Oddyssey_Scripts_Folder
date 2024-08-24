using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 1);
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1);
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        PlayerPrefs.SetFloat("musicVolume", _musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", _sfxSlider.value);
    }
}
