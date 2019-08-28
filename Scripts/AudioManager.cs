using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public Slider musicVolume, sfxVolume;
	// Use this for initialization
	void Start () {
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolume.value = PlayerPrefs.GetFloat("SfxVolume");
	}

    void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume.value);
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume.value);
    }
}
