using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileManager TileManager;

    public SpriteManager SpriteManager;

    public PrefabManager PrefabManager;

    public AnimationManager AnimationManager;

    public EntityManager EntityManager; 

    public UIManager UIManager;

    public MapLoader MapLoader;     

    public Camera Camera;


    bool _gamestarted = false; 

    public EntityAttribute PlayerAttributes; 

    public static GameManager GM; 
    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        TileManager = GetComponent<TileManager>();
        SpriteManager = GetComponent<SpriteManager>();
        PrefabManager = GetComponent<PrefabManager>();
        AnimationManager = GetComponent<AnimationManager>();
        UIManager = GetComponent<UIManager>();
        EntityManager = GetComponent<EntityManager>(); 
        _gamestarted = false; 
        StartCoroutine(LoadMod()); 
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAttributes == null && _gamestarted)
        {
            if (Camera == null)
                Camera = Instantiate(PrefabManager.GetPrefab("Main Camera")).GetComponent<Camera>();
            UIManager.HideGameUI(); 
            UIManager.SetScreenGameOver(); 
        }
    }



    IEnumerator LoadMod()
    {

        yield return null;
        UIManager.ShowLoadingBar();
        yield return StartCoroutine(TileManager.LoadTiles());
        UIManager.SetLoadingBarProgress(0.3f); 
        yield return StartCoroutine(SpriteManager.LoadSprites());
        UIManager.SetLoadingBarProgress(0.8f);
        yield return StartCoroutine(AnimationManager.LoadAnimations());
        UIManager.SetLoadingBarProgress(1); 
        UIManager.HideLoadingBar();
        yield return StartCoroutine(StartGame()); 
    }


    public void StartNewGame()
    {        
        _gamestarted = false; 
        UIManager.GameOverScreen.SetActive(false);        
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        MapLoader.ClearMap(); 
        yield return StartCoroutine(MapLoader.LoadMap("wasteland"));
        yield return StartCoroutine(MapLoader.SpawnEntities());
        yield return null; 
        var entityPrefab = PrefabManager.GetPrefab("Entity");
        var player = Instantiate(entityPrefab);
        player.name = "Player"; 
        player.AddComponent<PlayerController>();
        PlayerAttributes = player.GetComponent<EntityAttribute>();

        PlayerAttributes.LoadEntity(new EntityDefines()
        {
            Attributes = new Attributes()
            {
                Strength = 1,
                MaxHP = 100,
                Speed = 3,
                Dexterity = 1,
                Intellect = 1
            },
            EntityLayers = new List<EntityLayer>()
            {
                new EntityLayer() {DrawLayer = 1, Layername = "female_black", Color= Color.white},
                new EntityLayer() {DrawLayer = 2, Layername = "female_bangslong2", Color= Color.red}, 
                new EntityLayer() {DrawLayer = 3, Layername = "female_pants", Color= Color.blue},
                new EntityLayer() {DrawLayer = 4, Layername = "female_chainmail", Color= Color.white}
            },
            SpawnLocation = new Vector3Int(0, 0, 0),
            OnDeath = new OnDeath() { ChangeTiles = new List<TileData>(), ChangePlayerAttributes = new Attributes() }
        }) ;

        Camera.transform.parent = player.transform; 

        yield return null;
        UIManager.ShowGameUI(); 
        _gamestarted = true; 
    }
}
