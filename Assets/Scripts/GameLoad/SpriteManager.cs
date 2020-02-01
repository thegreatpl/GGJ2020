using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

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
        var files = Directory.GetFiles($"{FileLoader.ModPath}/{SpritePath}", "*.png", SearchOption.AllDirectories);
        int count = 0; 
        foreach(var file in files)
        {
            var texture = FileLoader.LoadTexture2D(file);
            var name = Path.GetFileNameWithoutExtension(file);


            for (int xdx = 0; xdx <= texture.width; xdx += 64)
            {
                for (int ydx = 0; ydx <= texture.height; ydx += 64)
                {
                    try
                    {
                        var sprite = Sprite.Create(texture, new Rect(xdx, ydx, 64, 64), new Vector2(0.5f, 0.5f), 32);
                        sprite.name = $"{name}_{xdx}_{ydx}";
                        Sprites.Add(sprite.name, sprite);
                    }
                    catch (Exception e)
                    {
                        Debug.Log($"Error loading tile: {e.Message}");
                    }
                }
            }
            count++; 
            if (count % 10 == 0)
                yield return null; 
        }

        //yield return null; 
    }
}
