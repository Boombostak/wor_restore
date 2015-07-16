using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameState : MonoBehaviour {

    public static GameState currentGS;
    public static PlayerTraits currentPT;
    public static Inventory currentInventory;
    public static HighScore currentHighScore;

    public GameState()
    {
        currentGS = new GameState();
        //not saved for kdays
        //currentPT = new PlayerTraits();
        //currentInventory = new Inventory();
        currentHighScore = new HighScore();
    }

}
