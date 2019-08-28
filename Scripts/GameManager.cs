using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager gm;

    public string gameMode;
    public int userAmount;
    public string selectedCharPlayer1;
    public string selectedCharPlayer2;
    public string selectedArena;
    public int roundAmount;
    public int selectedRoundTime;

    void Awake()
    {
        MakeThisTheOnlyGameManager();
    }

    void MakeThisTheOnlyGameManager()
    {
        if (gm == null)
        {
            DontDestroyOnLoad(gameObject);
            gm = this;
        }
        else
        {
            if (gm != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
