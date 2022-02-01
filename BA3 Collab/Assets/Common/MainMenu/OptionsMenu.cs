using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    //public void SetVolume (float volume)
    //{
    //    audioMixer.SetFloat("Volume", Mathf.Log10(volume)*20);
    //    Debug.Log(volume);
    //}

    private void Update()
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(slider.value) * 20);
    }
}
