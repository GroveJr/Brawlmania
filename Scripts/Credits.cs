using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(creditsScene());
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Pause"))
            SceneManager.LoadScene(0);
    }

    IEnumerator creditsScene()
    {
        yield return new WaitForSeconds(87);
        SceneManager.LoadScene(0);
    }
}
