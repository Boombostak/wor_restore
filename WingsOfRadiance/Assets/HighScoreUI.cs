using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour {

    public HighScore highscore;
    public List<ScoringPlayer> top10;
    public Text[] texts;
    public Dictionary<int, ScoringPlayer> dict;

    void OnEnable()
    {
        highscore = GameObject.Find("HighScoreManager").GetComponent < HighScore > ();
        top10 = highscore.top10;
        for (int i = 0; i < texts.Length; i++)
        {
            if (top10!=null)
            {
                if (top10[i]!=null)
                {
                    texts[i].text = i + top10[i].name + top10[i].score;
                    Debug.Log(texts[i].text);
                }
            }
        }
    }
}
