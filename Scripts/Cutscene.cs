using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour {
    public GameObject[] text;
    public GameObject api;
    Animator anim;
	// Use this for initialization
	void Start () {
        StartCoroutine(Text());
        api = GameObject.Find("API_Cutscene");
        anim = api.GetComponent<Animator>();
	}

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
            SceneManager.LoadScene(6);
    }

    IEnumerator Text()
    {
        yield return new WaitForSeconds(5);
        text[0].SetActive(false);
        text[1].SetActive(true);
        yield return new WaitForSeconds(5);
        text[1].SetActive(false);
        text[2].SetActive(true);
        yield return new WaitForSeconds(5);
        text[2].SetActive(false);
        text[3].SetActive(true);
        yield return new WaitForSeconds(5);
        text[3].SetActive(false);
        text[4].SetActive(true);
        yield return new WaitForSeconds(5);
        text[4].SetActive(false);
        text[5].SetActive(true);
        yield return new WaitForSeconds(5);
        text[5].SetActive(false);
        text[6].SetActive(true);
        yield return new WaitForSeconds(5);
        text[6].SetActive(false);
        text[7].SetActive(true);
        yield return new WaitForSeconds(5);
        text[7].SetActive(false);
        text[8].SetActive(true);
        anim.SetTrigger("Transform");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(6);
    }
}
