using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HighScore : MonoBehaviour
{

    //singleton
    public static HighScore _instance;
    public static HighScore instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<HighScore>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    public PlayerTraits playertraits;
    public Dictionary<int, ScoringPlayer> highScoreDict;
    public List<ScoringPlayer> playerList;
    public List<string> allnames;
    public IEnumerable<string> top10names;
    public List<string> top10nameslist;
    public List<int> allscores;
    public IEnumerable<int> top10scores;
    public List<int> top10scorelist;
    public static int IDIterator = 0;
    public bool originalHSM = false;

    void Awake()
    {
        //singleton
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }

        highScoreDict = new Dictionary<int, ScoringPlayer>();
        playerList = new List<ScoringPlayer>();
        allnames = new List<string>();
        allscores = new List<int>();
        top10names = new List<string>();
        top10scores = new List<int>();
        SaveLoad.Load();
        if (GameObject.FindGameObjectsWithTag("highscoremanager").Length <= 1)
        {
            GameObject.FindGameObjectWithTag("highscoremanager").GetComponent<HighScore>().originalHSM = true;
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("highscoremanager").Length > 1)
        {
            Debug.Log("Too many highscore managers");
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("highscoremanager"))
            {
                if (go.GetComponent<HighScore>().originalHSM == false)
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
        //Debug.Log("IDIterator before iteration " + IDIterator);
        IDIterator++;
        //Debug.Log("IDIterator after iteration " + IDIterator);
        player.name = playertraits.playername;
        //Debug.Log("Player name " + player.name);
        player.score = playertraits.xp;
        //Debug.Log("Player score " + player.score);
        highScoreDict.Add(player.ID, player);
        foreach (KeyValuePair<int, ScoringPlayer> kvp in highScoreDict)
        {
            Debug.Log("highscoredict" + kvp.Value.score);
        }
    }

    public void SortScores()
    {
        Debug.Log("Calling sortscore()");
        highScoreDict.OrderByDescending(x => x.Value.score);
        var sortedDict = from entry in highScoreDict orderby entry.Value.score descending select entry;
        Debug.Log(sortedDict.GetType());
        
        playerList = new List<ScoringPlayer>();
        foreach (KeyValuePair<int, ScoringPlayer> kvp in sortedDict)
        {
            playerList.Add(kvp.Value);
        }
        allnames = new List<string>();
        allscores = new List<int>();
        foreach (ScoringPlayer player in playerList)
        {
            allnames.Add(player.name);
            allscores.Add(player.score);
        }
        top10names = allnames.Take<string>(10);
        top10scores = allscores.Take<int>(10);
        top10nameslist = top10names.ToList();
        top10scorelist = top10scores.ToList();
    }
}

    public class ScoringPlayer : MonoBehaviour
    {
        public int ID;
        public string name;
        public int score;
    }