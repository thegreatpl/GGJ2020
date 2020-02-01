using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System;

public class TileManager : MonoBehaviour
{
    public const string TilePath = "Tiles"; 

    public Dictionary<string, TileBase> Tiles = new Dictionary<string, TileBase>();


    public GameObject TilePallete; 

    public TileBase NullTile; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public TileBase GetTile(string name)
    {
        if (Tiles.ContainsKey(name))
        {
            return Tiles[name]; 
        }
        return NullTile; 
    }

    public IEnumerator LoadTiles(bool runToComplete = false)
    {
        Tiles = new Dictionary<string, TileBase>(); 
        var files = Directory.GetFiles($"{FileLoader.ModPath}/{TilePath}", "*.png"); 

        foreach(var file in files)
        {
            var texture = FileLoader.LoadTexture2D(file);
            var name = Path.GetFileNameWithoutExtension(file);

            for(int xdx = 0; xdx <= texture.width; xdx += 32)
            {
                for (int ydx = 0; ydx <= texture.height; ydx += 32)
                {
                    try
                    {
                        var sprite = Sprite.Create(texture, new Rect(xdx, ydx, 32, 32), new Vector2(0.5f, 0.5f), 32);
                        sprite.name = $"{name}_{xdx}_{ydx}";
                        var tile = ScriptableObject.CreateInstance<Tile>();
                        tile.sprite = sprite;
                        tile.name = sprite.name;
                        Tiles.Add(tile.name, tile);
                    }
                    catch(Exception e)
                    {
                        Debug.Log($"Error loading tile: {e.Message}"); 
                    }
                }
            }
            if (!runToComplete)
                yield return null; 
        }
        yield return null; 
    }
}
