using UnityEngine;
using System.Collections;

public class PlayerRenderManager : MonoBehaviour {

    public SpriteRenderer[] renderers;
    public Weapon[] guns;

    void Awake()
    {
        Invoke("FindRenderers", 0.1f);
    }
    
    void OnLevelWasLoaded(int levelint)
    {
        Debug.Log("a level was loaded" + levelint);
        Invoke("FindRenderers", 0.1f);
    }
    
    public void FindRenderers()
    {
        renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        guns = transform.GetComponentsInChildren<Weapon>();
        SetRenderers();
    }

    public void SetRenderers(){
        if (Application.loadedLevelName == "test"){for (int i = 0; i < renderers.Length; i++){renderers[i].enabled = true;}}
        if (Application.loadedLevelName == "test"){for (int i = 0; i < guns.Length; i++){guns[i].enabled = true;}}
        if (Application.loadedLevelName == "homebase"){for (int i = 0; i < renderers.Length; i++){renderers[i].enabled = false;}}
        if (Application.loadedLevelName == "homebase"){for (int i = 0; i < guns.Length; i++){guns[i].enabled = false;}}
    }
    
    
}
