using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileManager TileManager;

    public SpriteManager SpriteManager;

    public PrefabManager PrefabManager; 


    public static GameManager GM; 
    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        TileManager = GetComponent<TileManager>();
        SpriteManager = GetComponent<SpriteManager>();
        PrefabManager = GetComponent<PrefabManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
