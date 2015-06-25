using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameState : MonoBehaviour {

    public static GameState currentGS;
    public static PlayerTraits currentPT;
    public static Inventory currentInventory;

    public GameState()
    {
        currentGS = new GameState();
        currentPT = new PlayerTraits();
        currentInventory = new Inventory();
    }

}
