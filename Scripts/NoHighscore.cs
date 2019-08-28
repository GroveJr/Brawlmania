using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoHighscore : MonoBehaviour {
    public Text score;
    void Awake()
    {
        score.text = ArcadeManager.am.score.ToString("F2");
    }
}
