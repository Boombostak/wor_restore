using UnityEngine;
using System.Collections;

public class EnemyManagerGO : MonoBehaviour {

    private GameObject player;
	public int level_int;
	private GameObject selectedmission;
	private GameObject startingtile;

    private GameObject level_selectionGO;
    private GameObject enemyfaction_selectionGO;
	private GameObject enemytype_selectionGO;
    private GameObject enemyrarity_selectionGO;
    private GameObject chosenenemy_selectionGO;
    private GameObject clone_to_spawn;
    public GameObject thing_to_spawn;
    public GameObject enemytospawn;
    private GameObject[] enemytable;

    private int typerng;
    private int typelength;
    private int rarityrng;
    private int raritylength;
    private int chosenenemyrng;
    private int chosenenemylength;

    //Make a persistent singleton

    private static EnemyManagerGO _instance;
    public static EnemyManagerGO instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EnemyManagerGO>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Finds player GO.
		selectedmission = SharedVariables.selectedmission.gameObject;
		level_int = selectedmission.GetComponent<Mission>().missionlevel; //Defines the mission level.
        level_selectionGO = this.transform.GetChild(level_int).gameObject;
        //Debug.Log(level_selectionGO);
        thing_to_spawn = new GameObject();

    }

    public GameObject SpawnAnEnemy(Transform where, string faction, string enemy_type)
    {
		//Debug.Log (where + faction + enemy_type);
		enemyfaction_selectionGO = level_selectionGO.transform.FindChild(faction).gameObject;
		enemytype_selectionGO = enemyfaction_selectionGO.transform.FindChild(enemy_type).gameObject;
		//enemytype_selectionGO = level_selectionGO.transform.GetChild(Random.Range(0, level_selectionGO.transform.childCount)).gameObject;
		//Debug.Log(enemytype_selectionGO);
        enemyrarity_selectionGO = enemytype_selectionGO.transform.GetChild(Random.Range(0, enemytype_selectionGO.transform.childCount)).gameObject;
		//Debug.Log(enemyrarity_selectionGO);
        enemytable = enemyrarity_selectionGO.GetComponent<EnemyTable>().enemies;
        chosenenemy_selectionGO = enemytable[Random.Range(0, enemytable.Length)];
        thing_to_spawn = Instantiate(chosenenemy_selectionGO, where.position, where.rotation) as GameObject;
        //Debug.Log("levelint " + level_int);
        return thing_to_spawn;
    }

    //copies the fields of a component and adds a duplicate component to a gameobject
    public Component CopyComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        // Copied fields can be restricted with BindingFlags
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }
}