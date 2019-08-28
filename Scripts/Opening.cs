using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour {
    GameObject bg;
    RawImage rawImage;
    public Texture tex;
	void Start () {
        rawImage = bg.GetComponent<RawImage>();
        StartCoroutine(NextScene());
	}

	void Update()
    {
        if(Input.GetButtonDown("Pause"))
            SceneManager.LoadScene(6);
    }

    void Awake()
    {
        bg = GameObject.Find("Background");
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(21);
        rawImage.texture = tex;
        yield return new WaitForSeconds(23);
        SceneManager.LoadScene(6);
    }
}
