using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public int roundTime, p1Win, p2Win;
    public int currentRound;
    private float lastTimeUpdate = 0;
    private bool battleStarted;
    private bool battleEnded;

    public Fighter player1;
    public Fighter player2;
    public BannerManager banner;

    public bool paused;
    public GameObject pausePanel;
    public GameObject newHighscore, noHighscore;
    public Button resume, returnMainMenu;

    public GameObject[] fighters;
    private GameObject spawnPoint1, spawnPoint2;

    GameObject spawn1, spawn2;
    // Use this for initialization
    void Start()
    {
        if (GameManager.gm.gameMode == "arcade")
            roundTime = 60;
        else if (GameManager.gm.gameMode == "versus")
            roundTime = GameManager.gm.selectedRoundTime;

        p1Win = 0;
        p2Win = 0;

        paused = false;
        resume.onClick.AddListener(ResumeGame);
        returnMainMenu.onClick.AddListener(ResumeGame);
    }

    void Awake()
    {
        spawnPoint1 = GameObject.Find("SpawnPointLeft");
        spawnPoint2 = GameObject.Find("SpawnPointRight");        

        //Player1 spawn
        if (GameManager.gm.selectedCharPlayer1 == "FIKom")
        {
            spawn1= Instantiate(fighters[0], spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            spawn1.name = "Player 1";            
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FPsi")
        {
            spawn1 = Instantiate(fighters[1], spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            spawn1.name = "Player 1";            
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FK")
        {
            spawn1 = Instantiate(fighters[2], spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            spawn1.name = "Player 1";            
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FE")
        {
            spawn1 = Instantiate(fighters[3], spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            spawn1.name = "Player 1";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FT")
        {
            spawn1 = Instantiate(fighters[4], spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            spawn1.name = "Player 1";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FH")
        {
            spawn1 = Instantiate(fighters[5], spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            spawn1.name = "Player 1";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FSRD")
        {
            spawn1 = Instantiate(fighters[6], spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            spawn1.name = "Player 1";
        }
        else if (GameManager.gm.selectedCharPlayer1 == "FTI")
        {
            spawn1 = Instantiate(fighters[7], spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            spawn1.name = "Player 1";
        }

        //Player2 spawn
        if (GameManager.gm.selectedCharPlayer2 == "FIKom")
        {
            spawn2 = Instantiate(fighters[0], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            spawn2.name = "Player 2";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FPsi")
        {
            spawn2 = Instantiate(fighters[1], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            spawn2.name = "Player 2";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FK")
        {
            spawn2 = Instantiate(fighters[2], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            spawn2.name = "Player 2";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FE")
        {
            spawn2 = Instantiate(fighters[3], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            spawn2.name = "Player 2";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FT")
        {
            spawn2 = Instantiate(fighters[4], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            spawn2.name = "Player 2";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FH")
        {
            spawn2 = Instantiate(fighters[5], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            spawn2.name = "Player 2";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FSRD")
        {
            spawn2 = Instantiate(fighters[6], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            spawn2.name = "Player 2";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "FTI")
        {
            spawn2 = Instantiate(fighters[7], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            spawn2.name = "Player 2";
        }
        else if (GameManager.gm.selectedCharPlayer2 == "API")
        {
            spawn2 = Instantiate(fighters[8], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            spawn2.name = "Player 2";
        }

        //Practice
        if (GameManager.gm.gameMode=="practice")
            spawn2 = Instantiate(fighters[8], spawnPoint2.transform.position, spawnPoint2.transform.rotation);

        player1 = spawn1.GetComponent<Fighter>();
        player2 = spawn2.GetComponent<Fighter>();
        if (GameManager.gm.gameMode == "versus" && GameManager.gm.userAmount == 2)
            player2.player = Fighter.PlayerType.PLAYER2;
        else if (GameManager.gm.gameMode=="arcade" || (GameManager.gm.gameMode == "versus" && GameManager.gm.userAmount == 1))
            player2.player = Fighter.PlayerType.AI;        
    }

    private void ExpireTime()
    {
        if (player1.healthPercent > player2.healthPercent)
        {
            player2.health = 0;
        }
        else
        {
            player1.health = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!battleStarted)
        {
            if (GameManager.gm.gameMode != "practice")
                banner.Fight();

            battleStarted = true;
            currentRound += 1;
            player1.enable = true;
            player2.enable = true;
        }

        if (battleStarted && !battleEnded)
        {
            if (roundTime > 0 && Time.time - lastTimeUpdate > 1)
            {
                roundTime--;
                lastTimeUpdate = Time.time;
                if (roundTime == 0)
                {
                    ExpireTime();
                }
            }

            if (player1.healthPercent <= 0)
            {
                if (GameManager.gm.userAmount == 1)
                    banner.YouLose();
                else if (GameManager.gm.userAmount == 2)
                    banner.P2Win();
                p2Win++;
                battleEnded = true;                
            }
            else if (player2.healthPercent <= 0)
            {
                if (GameManager.gm.userAmount == 1)
                    banner.YouWin();
                else if (GameManager.gm.userAmount == 2)
                    banner.P1Win();
                p1Win++;
                battleEnded = true;                
            }
        }

        if (GameManager.gm.gameMode == "practice")
        {
            player1.health = 1000;
            player2.health = 1000;
        }

        if (Input.GetButtonDown("Pause"))
            paused = true;
        if (paused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        } 
        else if (!paused)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }

        //Debug
        if(paused)
        {
            if (GameManager.gm.gameMode == "arcade")
            {
                if (Input.GetKeyDown(KeyCode.F12))
                {
                    newHighscore.SetActive(true);
                    noHighscore.SetActive(true);
                }
            }
        }
    }

    void ResumeGame()
    {
        paused = false;
    }

    void ToVersus()
    {
        if (ArcadeManager.am.win < 7)
            SceneManager.LoadScene(6);
        else if (ArcadeManager.am.win == 7)
            SceneManager.LoadScene(17);
        else
        {
            string jsonString = File.ReadAllText(Application.dataPath + "/highscore.json");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            if (highscores.highscoreEntryList[9].score < ArcadeManager.am.score)
                SceneManager.LoadScene(19);
            else
                SceneManager.LoadScene(20);
        }
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public float score;
        public string name;
    }

    public void NextFight()
    {
        if (GameManager.gm.gameMode == "versus")
        {
            if (p1Win == 1 || p2Win == 1)
            {
                if (GameManager.gm.roundAmount != 1)
                {
                    roundTime = GameManager.gm.selectedRoundTime;
                    player1.ultimate = false;
                    player2.ultimate = false;
                    if (player1.tag == "FK")
                        player1.anim.SetBool("Monster", false);
                    if (player2.tag == "FK")
                        player2.anim.SetBool("Monster", false);
                    player1.health = 1000;
                    player2.health = 1000;
                    player1.transform.position = spawnPoint1.transform.position;
                    player2.transform.position = spawnPoint2.transform.position;
                    battleStarted = false;
                    battleEnded = false;
                }
                else
                {
                    SceneManager.LoadScene(0);
                    GameManager.gm.gameMode = "";
                    GameManager.gm.userAmount = 0;
                    GameManager.gm.selectedCharPlayer1 = "";
                    GameManager.gm.selectedCharPlayer2 = "";
                    GameManager.gm.selectedArena = "";
                    GameManager.gm.roundAmount = 0;
                    GameManager.gm.selectedRoundTime = 0;
                }
            }
            if (p1Win == 2 || p2Win == 2)
            {
                SceneManager.LoadScene(0);
                GameManager.gm.gameMode = "";
                GameManager.gm.userAmount = 0;
                GameManager.gm.selectedCharPlayer1 = "";
                GameManager.gm.selectedCharPlayer2 = "";
                GameManager.gm.selectedArena = "";
                GameManager.gm.roundAmount = 0;
                GameManager.gm.selectedRoundTime = 0;
            }
        }
        else if (GameManager.gm.gameMode == "arcade")
        {
            if (p1Win == 1 || p2Win == 1)
            {
                if (GameManager.gm.roundAmount != 1)
                {
                    if (p1Win == 1)
                    {
                        if (ArcadeManager.am.score < 4)
                            ArcadeManager.am.score += (player1.healthPercent * 100) / 1200 * 4;
                        else
                            ArcadeManager.am.score = 4;
                    }
                    roundTime = 60;
                    player1.ultimate = false;
                    player2.ultimate = false;
                    if (player1.tag == "FK")
                        player1.anim.SetBool("Monster", false);
                    if (player2.tag == "FK")
                        player2.anim.SetBool("Monster", false);
                    player1.health = 1000;
                    player2.health = 1000;
                    player1.transform.position = spawnPoint1.transform.position;
                    player2.transform.position = spawnPoint2.transform.position;
                    battleStarted = false;
                    battleEnded = false;
                }
            }

            if (p2Win == 2)
            {
                GameManager.gm.gameMode = "";
                GameManager.gm.userAmount = 0;
                GameManager.gm.selectedCharPlayer1 = "";
                GameManager.gm.selectedCharPlayer2 = "";
                GameManager.gm.selectedArena = "";
                GameManager.gm.roundAmount = 0;
                GameManager.gm.selectedRoundTime = 0;
                ArcadeManager.am.win = 0;
                ArcadeManager.am.score = 0;
                SceneManager.LoadScene(0);
            }
            else if (p1Win == 2)
            {
                if (ArcadeManager.am.score < 4)
                    ArcadeManager.am.score += (player1.healthPercent * 100) / 1200 * 4;
                else
                    ArcadeManager.am.score = 4;
                ArcadeManager.am.win++;
                Invoke("ToVersus", 1);
            }
        }
    }
}
