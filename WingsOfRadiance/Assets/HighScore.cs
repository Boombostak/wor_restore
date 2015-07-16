using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HighScore : MonoBehaviour {

    public PlayerTraits playertraits;
    public static Dictionary<int, ScoringPlayer> highScoreDict;
    public List<ScoringPlayer> top10;
    public ScoringPlayer[] top10array;
    public string[] top10names;
    public int[] top10scores;
    public static int IDIterator = 0;
    public bool originalHSM = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        highScoreDict = new Dictionary<int,ScoringPlayer>();
        top10 = new List<ScoringPlayer>();
        top10array = new ScoringPlayer[10];
        top10names = new string[10];
        top10scores = new int[10];
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
        highScoreDict.OrderByDescending(x => x.Value.score);
        top10.AddRange(highScoreDict.Values);
        top10array = top10.ToArray();
        for (int i = 0; i < top10array.Length; i++)
        {
            top10names[i] = top10array[i].name;
        }
        for (int i = 0; i < top10array.Length; i++)
        {
            top10scores[i] = top10array[i].score;
        }
        }
    }

    public class ScoringPlayer:MonoBehaviour{
        public int ID;
        public string name;
        public int score;
    }