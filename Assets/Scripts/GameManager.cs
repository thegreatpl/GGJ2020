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

    public AudioSource MusicPlayer;

    public AudioClip music; 

    /// <summary>
    /// The gameinit file. 
    /// </summary>
    public GameInit GameInit;

    int _currentLevel; 


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
            {
                Camera = Instantiate(PrefabManager.GetPrefab("Main Camera")).GetComponent<Camera>();
                MusicPlayer = Camera.gameObject.GetComponent<AudioSource>();
                MusicPlayer.clip = music;
                MusicPlayer.Play(); 
            }
            UIManager.HideGameUI(); 
            UIManager.SetScreenGameOver(); 
        }

        if (EntityManager.Entities.Count < 2 && _gamestarted)
        {
            _currentLevel++;
            if (GameInit.Levels.Length <= _currentLevel)
                _currentLevel = 0;
            StartCoroutine(LoadMap()); 
        }
    }



    IEnumerator LoadMod()
    {

        yield return null;
        UIManager.ShowLoadingBar();
        yield return StartCoroutine(TileManager.LoadTiles());
        UIManager.SetLoadingBarProgress(0.3f); 
        yield return StartCoroutine(SpriteManager.LoadSprites());
        UIManager.SetLoadingBarProgress(0.7f);
        yield return StartCoroutine(AnimationManager.LoadAnimations());
        UIManager.SetLoadingBarProgress(0.8f);
        GameInit = FileLoader.LoadJson<GameInit>($"{FileLoader.ModPath}/Game.init"); 
        UIManager.SetLoadingBarProgress(0.9f);
        if (!string.IsNullOrWhiteSpace(GameInit.BackGroundMusic ))
            yield return StartCoroutine(FileLoader.LoadAudio($"file://{FileLoader.ModPath}/{GameInit.BackGroundMusic}", (AudioClip x) => { music = x; }));
        MusicPlayer.clip = music;
        MusicPlayer.Play(); 
        UIManager.SetLoadingBarProgress(1); 
        UIManager.HideLoadingBar();
        UIManager.SetScreenGameOver(); 
        //yield return StartCoroutine(StartGame()); 
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
        _currentLevel = 0;
        var entityPrefab = PrefabManager.GetPrefab("Entity");
        var player = Instantiate(entityPrefab);
        player.SetActive(false);
        player.name = "Player"; 
        player.AddComponent<PlayerController>();
        var heal = player.AddComponent<PeacefulHeal>();
        heal.HealingTiles = GameInit.HealingTiles; 
        PlayerAttributes = player.GetComponent<EntityAttribute>();

        PlayerAttributes.LoadEntity(GameInit.PlayerDefines);
        yield return StartCoroutine(LoadMap());         

        yield return null;
        UIManager.ShowGameUI(); 
        _gamestarted = true; 
    }


    IEnumerator LoadMap()
    {
        _gamestarted = false; 
        Camera.transform.parent = null; 
        PlayerAttributes.gameObject.SetActive(false); 
        yield return StartCoroutine(MapLoader.LoadMap(GameInit.Levels[_currentLevel].LevelFile));
        yield return StartCoroutine(MapLoader.SpawnEntities());
        PlayerAttributes.transform.position = GameInit.Levels[_currentLevel].SpawnLoc;        

        PlayerAttributes.gameObject.SetActive(true);  
        Camera.transform.parent = PlayerAttributes.transform;
        _gamestarted = true; 
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }
}
