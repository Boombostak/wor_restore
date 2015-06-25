using UnityEngine;
using System.Collections;

public class BackgroundBehaviourHoriz : MonoBehaviour {

	//vertical scrolling
    //linking to n appropriate backgrounds

    public GameObject[] bg_options;
    public int bg_rng;
    public GameObject bg_selection;
    public float scrollspeed_x = 10;
    public Vector3 offset;
    bool hasrunonce = false;
    public float culling_x_position = 25f;
    
    // Use this for initialization
	void Start () {
        bg_rng = Random.Range(0, bg_options.Length);
        bg_selection = bg_options[bg_rng];
	}
	
	// Update is called once per frame
    void Update()
    {
        this.transform.Translate(scrollspeed_x * Time.deltaTime, 0, 0);

        if (this.transform.position.x > culling_x_position)
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.x < culling_x_position && this.transform.position.x >0)
        {
            SpawnBG();
        }
    }

    public void SpawnBG()
    {
        if (!hasrunonce)
        {
            hasrunonce = true;
            offset = new Vector3(this.transform.position.x - this.GetComponent<SpriteRenderer>().bounds.size.x, 0 ,0);
            Instantiate(bg_selection, offset, this.transform.rotation);
        }
        
    }

    /*void OnBecameVisible() //deprecated
    {
        offset = new Vector3(0, this.transform.position.y + this.GetComponent<SpriteRenderer>().bounds.size.y, 0);
        Instantiate(bg_selection, offset, this.transform.rotation);
    }*/
}
