using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewHighscore : MonoBehaviour {
    public Text score;
    public InputField input;

    void Awake()
    {
        score.text = ArcadeManager.am.score.ToString("F2");
    }

    public void HighscoreSave()
    {
        if (input.text == "")
            ArcadeManager.am.arcadeName = "AAA";
        else
            ArcadeManager.am.arcadeName = input.text.ToUpper();

        string jsonString = File.ReadAllText(Application.dataPath + "/highscore.json");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores.highscoreEntryList[9].score < ArcadeManager.am.score)
        {
            highscores.highscoreEntryList[9].score = ArcadeManager.am.score;
            highscores.highscoreEntryList[9].name = ArcadeManager.am.arcadeName;
        }

        highscores = new Highscores { highscoreEntryList = highscores.highscoreEntryList };
        highscores.highscoreEntryList = highscores.highscoreEntryList.OrderByDescending(highscore => highscore.score).ToList();
        string json = JsonUtility.ToJson(highscores);
        File.WriteAllText(Application.dataPath + "/highscore.json", json);
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
