using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreTable : MonoBehaviour {
    private Transform entryContainer;
    private Transform entryTemplate;
    //private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    void Awake()
    {
        ArcadeManager.am.score = 0;
        ArcadeManager.am.win = 0;
        ArcadeManager.am.arcadeName = null;

        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //highscoreEntryList = new List<HighscoreEntry>()
        //{
        //    new HighscoreEntry{score=3.6f,name="AAA" },
        //    new HighscoreEntry{score=3.5f,name="ASD" },
        //    new HighscoreEntry{score=3.4f,name="ABC" },
        //    new HighscoreEntry{score=3.3f,name="EXE" },
        //    new HighscoreEntry{score=3.2f,name="PNG" },
        //    new HighscoreEntry{score=3.1f,name="PSD" },
        //    new HighscoreEntry{score=3.0f,name="TRY" },
        //    new HighscoreEntry{score=2.9f,name="POO" },
        //    new HighscoreEntry{score=2.8f,name="OMG" },
        //    new HighscoreEntry{score=2.7f,name="WTF" },
        //};

        string jsonString = File.ReadAllText(Application.dataPath + "/highscore.json");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        //Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        //string json = JsonUtility.ToJson(highscores);
        //File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
            SceneManager.LoadScene(0);
    }

    void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 50f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        float score = highscoreEntry.score;
        string name = highscoreEntry.name;

        entryTransform.Find("Pos").GetComponent<Text>().text = rankString;
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString("F2");
        entryTransform.Find("Name").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
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
}
