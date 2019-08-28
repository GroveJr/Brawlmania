using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadByMode()
    {
        if (GameManager.gm.gameMode == "arcade")
        {
            SceneManager.LoadScene(16);
        }
        else if (GameManager.gm.gameMode == "versus")
        {
            if (GameManager.gm.selectedCharPlayer2 != "")
                SceneManager.LoadScene(3);
        }
        else if (GameManager.gm.gameMode == "practice")
        {
            SceneManager.LoadScene(2);
        }
    }
}
