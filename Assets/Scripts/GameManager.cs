using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileManager TileManager;

    public SpriteManager SpriteManager;

    public PrefabManager PrefabManager;

    public AnimationManager AnimationManager;

    public UIManager UIManager; 

    public Camera Camera; 

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

        StartCoroutine(LoadMod()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator LoadMod()
    {

        yield return null;
        UIManager.ShowLoadingBar();
        yield return StartCoroutine(TileManager.LoadTiles());
        UIManager.SetLoadingBarProgress(0.2f); 
        yield return StartCoroutine(SpriteManager.LoadSprites());
        UIManager.SetLoadingBarProgress(0.8f);
        yield return StartCoroutine(AnimationManager.LoadAnimations());
        UIManager.SetLoadingBarProgress(1); 
        UIManager.HideLoadingBar();
        yield return StartCoroutine(StartGame()); 
    }


    IEnumerator StartGame()
    {
        var entityPrefab = PrefabManager.GetPrefab("Entity");
        var player = Instantiate(entityPrefab);
        player.AddComponent<PlayerController>();

        var layer = PrefabManager.GetPrefab("SpriteLayer");
        var anaimationLayer = Instantiate(layer, player.transform); 
        anaimationLayer.GetComponent<AnimationLayer>().AssignAnimation(AnimationManager.GetAnimation("female_black"));

        Camera.transform.parent = player.transform; 

        yield return null; 
    }
}
