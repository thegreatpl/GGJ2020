using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

public class SpriteManager : MonoBehaviour
{
    public const string SpritePath = "Sprites";


    public Dictionary<string, Sprite> Sprites = new Dictionary<string, Sprite>();

    public Sprite NullSprite; 

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public IEnumerator LoadSprites()
    {
        yield return null; 
    }
}
