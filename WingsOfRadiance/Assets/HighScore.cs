using UnityEngine;
using System.Collections.Generic;

public class HighScore : MonoBehaviour {

    public PlayerTraits playertraits;
    public static Dictionary<int, ScoringPlayer> highScoreDict;
    public List<int> scores;
    public List<ScoringPlayer> players;
    public static int IDIterator = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        highScoreDict = new Dictionary<int,ScoringPlayer>();
        players = new List<ScoringPlayer>();
    }
    
    public void ConstructHighscore()
    {
        ScoringPlayer player = new ScoringPlayer();
        playertraits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTraits>();
        
        player.ID = IDIterator;
        Debug.Log("IDIterator before iteration " + IDIterator);
        IDIterator++;
        Debug.Log("IDIterator after iteration " + IDIterator);
        player.name = playertraits.playername;
        Debug.Log("Player name " + player.name);
        player.score = playertraits.xp;
        Debug.Log("Player score " + player.score);
        highScoreDict.Add(player.ID, player);
    }

    public void SortScores()
    {
        scores = new List<int>();
        foreach (KeyValuePair<int, ScoringPlayer> kvp in highScoreDict)
        {
            players.Add(kvp.Value);
        }

        foreach (ScoringPlayer sp in players)
        {
            scores.Add(sp.score);
        }

        scores.Sort((a, b) => -1 * a.CompareTo(b)); // descending sort
    }

    public class ScoringPlayer{
        public int ID;
        public string name;
        public int score;
    }
}
