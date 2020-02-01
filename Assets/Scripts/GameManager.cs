using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileManager TileManager;

    public SpriteManager SpriteManager;

    public PrefabManager PrefabManager;

    public AnimationManager AnimationManager; 

    public static GameManager GM; 
    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        TileManager = GetComponent<TileManager>();
        SpriteManager = GetComponent<SpriteManager>();
        PrefabManager = GetComponent<PrefabManager>();
        AnimationManager = GetComponent<AnimationManager>();

        StartCoroutine(LoadMod()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator LoadMod()
    {
        yield return null; 
        yield return StartCoroutine(TileManager.LoadTiles());
        yield return StartCoroutine(SpriteManager.LoadSprites());
        yield return StartCoroutine(AnimationManager.LoadAnimations()); 
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

        yield return null; 
    }
}
