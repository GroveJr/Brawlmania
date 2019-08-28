using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    public static MusicManager mm;
    public AudioSource source;
    public AudioClip[] bgm;

	void Awake () {
        MakeThisTheOnlyMusicManager();
        source = GetComponent<AudioSource>();
	}

    void Update()
    {
        source.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            source.clip = bgm[0];
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (source.clip != bgm[1])
            {
                source.clip = bgm[1];
                source.Play();
            }
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            source.clip = bgm[12];
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            source.clip = bgm[13];
            source.Play();
            source.loop = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            source.clip = bgm[2];
            BossMusic();
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            source.clip = bgm[3];
            BossMusic();
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            source.clip = bgm[4];
            BossMusic();
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            source.clip = bgm[5];
            BossMusic();
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            source.clip = bgm[6];
            BossMusic();
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 12)
        {
            source.clip = bgm[7];
            BossMusic();
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            source.clip = bgm[8];
            BossMusic();
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            source.clip = bgm[9];
            BossMusic();
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 15)
        {
            source.clip = bgm[11];
            source.Play();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            source.clip = bgm[14];
            source.Play();
            source.loop = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            source.clip = bgm[15];
            source.Play();
            source.loop = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 18 || SceneManager.GetActiveScene().buildIndex == 19 || SceneManager.GetActiveScene().buildIndex == 20)
        {
            if (source.clip != bgm[16])
            {
                source.clip = bgm[16];
                source.Play();
            }
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 21)
        {
            source.clip = bgm[17];
            source.Play();
            source.loop = false;
        }
    }

    void BossMusic()
    {
        if (ArcadeManager.am.win == 7)
            source.clip = bgm[10];
    }

    void MakeThisTheOnlyMusicManager()
    {
        if (mm == null)
        {
            DontDestroyOnLoad(gameObject);
            mm = this;
        }
        else
        {
            if (mm != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
