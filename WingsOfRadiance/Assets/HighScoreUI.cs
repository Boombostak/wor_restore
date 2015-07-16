using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour {

    public HighScore highscore;
    public List<int> scores;
    public Text[][] texts;
    public Dictionary<int, HighScore.ScoringPlayer> dict;

    /*void OnEnable()
    {
        highscore = GameObject.Find("HighScoreManager").GetComponent < HighScore > ();
        scores = highscore.scores;

        texts[0][0].text = "1. " + scores[0];
    }*/
}
