using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour {

    public HighScore highscore;
    public Text UItext1;
    public Text UItext2;
    public List<string> names;
    public List<int> scores;

    void OnEnable()
    {
        highscore = GameObject.FindObjectOfType<HighScore>();
        names = highscore.top10nameslist;
        scores = highscore.top10scorelist;
        UItext1.text = null;
        for (int i = 0; i < names.Count; i++)
        {
            UItext1.text += i+1+". " +names[i] + " " + scores[i] + "\n";
        }
        UItext2.text = UItext1.text;
    }
}
