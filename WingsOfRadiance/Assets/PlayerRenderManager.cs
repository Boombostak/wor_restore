using UnityEngine;
using System.Collections;

public class PlayerRenderManager : MonoBehaviour {

    public SpriteRenderer[] renderers;
    public Weapon[] guns;
    public bool playerIsDead = false;

    void Awake()
    {
        Invoke("FindRenderers", 0.1f);
    }
    
    //makes player a lazy singleton
    void OnLevelWasLoaded(int levelint)
    {
        Debug.Log("a level was loaded" + levelint);
        Invoke("FindRenderers", 0.1f);
        Debug.Log("There are " + GameObject.FindObjectsOfType<PlayerTraits>().Length + " players");
        if ((GameObject.FindObjectsOfType<PlayerTraits>().Length > 1))
        {
            if (this.GetComponent<PlayerTraits>().playername == "")
            {
                Debug.Log("a player has no name");
                Destroy(this.gameObject);
            }
            
        }
    }
    
    public void FindRenderers()
    {
        renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        guns = transform.GetComponentsInChildren<Weapon>();
        SetRenderers();
    }

    public void SetRenderers(){
        if (Application.loadedLevelName == "test") { for (int i = 0; i < renderers.Length; i++) { renderers[i].enabled = true; playerIsDead = false; } }
        if (Application.loadedLevelName == "test") { for (int i = 0; i < guns.Length; i++) { guns[i].enabled = true; playerIsDead = false; } }
        if (Application.loadedLevelName == "homebase") { for (int i = 0; i < renderers.Length; i++) { renderers[i].enabled = false; playerIsDead = false; } }
        if (Application.loadedLevelName == "homebase") { for (int i = 0; i < guns.Length; i++) { guns[i].enabled = false; playerIsDead = false; } }
        if (playerIsDead == true) { for (int i = 0; i < renderers.Length; i++) { renderers[i].enabled = false; } }
        if (playerIsDead == true) { for (int i = 0; i < guns.Length; i++) { guns[i].enabled = false; } }
    }
}
