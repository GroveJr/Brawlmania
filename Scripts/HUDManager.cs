using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Fighter player1;
    public Fighter player2;

    public Text player1Tag;
    public Text player2Tag;

    public Scrollbar leftBar;
    public Scrollbar rightBar;

    public Text timerText;
    public Text roundText;
    public Text scoreText;

    public BattleManager battle;

    public GameObject infinity;
    public GameObject timer;
    public GameObject round;
    public GameObject score;
    public GameObject P1Star1;
    public GameObject P1Star2;
    public GameObject P2Star1;
    public GameObject P2Star2;
    // Use this for initialization
    void Start () {
        if (GameManager.gm.gameMode == "practice")
        {
            infinity.SetActive(true);
            timer.SetActive(false);
            round.SetActive(false);
        }

        if (GameManager.gm.gameMode == "arcade")
            score.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        player1 = battle.player1;
        player2 = battle.player2;
        player1Tag.text = player1.fighterName;
        player2Tag.text = player2.fighterName;
        
        if (GameManager.gm.gameMode != "practice")
        {
            timerText.text = battle.roundTime.ToString();
            roundText.text = "ROUND " + battle.currentRound.ToString();
        }

        if (GameManager.gm.gameMode == "arcade")
            scoreText.text = ArcadeManager.am.score.ToString("F2");

        leftBar.size = player1.healthPercent;
        rightBar.size = player2.healthPercent;

        if (battle.p1Win == 1)
        {
            P1Star1.SetActive(true);
        }
        if (battle.p1Win == 2)
        {
            P1Star2.SetActive(true);
        }
        if (battle.p2Win == 1)
        {
            P2Star1.SetActive(true);
        }
        if (battle.p2Win == 2)
        {
            P2Star2.SetActive(true);
        }
    }
}
