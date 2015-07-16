using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HighScore : MonoBehaviour {

    public PlayerTraits playertraits;
    public static Dictionary<int, ScoringPlayer> highScoreDict;
    public List<int> scores;
    public List<ScoringPlayer> players;
    public ScoringPlayer[] top10;
    public static int IDIterator = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        highScoreDict = new Dictionary<int,ScoringPlayer>();
        players = new List<ScoringPlayer>();
        top10 = new ScoringPlayer[10];
        SaveLoad.Load();
        SortScores();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("highscoremanager").Length > 1)
        {
            Debug.Log("Too many highscore managers");
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("highscoremanager"))
            {
                if (go.GetComponent<HighScore>().scores.Count < 1)
                {
                    Destroy(go.gameObject);
                }
            }
            
        }
    }

    void OnApplicationQuit()
    {
        GameState.currentHighScore = this;
        SaveLoad.Save();
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
        
        players.OrderByDescending(x => x.score);
        for (int i = 0; i < 9; i++)
        {
            //this is causing crashes
            if (top10[i]!=null && players[i] != null)
            {
            top10[i] = players[i];
            }
        }
    }

    public class ScoringPlayer{
        public int ID;
        public string name;
        public int score;
    }
}
