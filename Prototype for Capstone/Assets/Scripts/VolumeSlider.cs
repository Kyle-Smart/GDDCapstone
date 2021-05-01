using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    private Slider volumeSlider;

    private void Start()
    {
        //The reverse of setVolumes math to set the slider value between levels
        float value;
        volumeSlider = GetComponent<Slider>();
        bool result = mixer.GetFloat("MusicVol", out value);
        value = Mathf.Pow(10, (value / 20)); 
        if (volumeSlider.value != value) volumeSlider.value = value;
    }

    public void setVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        GameManager.Instance.volumeLevel = volumeSlider.value;
    }
}
