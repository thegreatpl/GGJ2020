using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLoader : MonoBehaviour
{
    public string Name; 

    public Tilemap BackGround;

    public Tilemap Walls;

    public Tilemap Foreground; 

    Map Map;

    public const string MapFolder = "Maps"; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /// <summary>
    /// Saves a map to disk. 
    /// </summary>
    /// <param name="filename"></param>
    public void SaveMap(string filename)
    {
        Map = new Map()
        {
            BackGround = BackGround.GetAllTileData().ToList(),
            ForeGround = Foreground.GetAllTileData().ToList(),
            Walls = Walls.GetAllTileData().ToList()
        };

        FileLoader.SaveAsJson($"{GetDefaultFilePath()}/{filename}.map", Map); 
    }

    
    /// <summary>
    /// Loads a map from file. 
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public IEnumerator LoadMap(string filename)
    {
        Map = FileLoader.LoadJson<Map>($"{GetDefaultFilePath()}/{filename}.map");
        BackGround.ClearAllTiles();
        Foreground.ClearAllTiles();
        Walls.ClearAllTiles();
        int count = 0; 
        foreach(var tile in Map.BackGround)
        {
            BackGround.SetTile(tile.Postion, GameManager.GM.TileManager.GetTile(tile.TileName)); 

            if (count >= 100)
            {
                count = 0; 
                yield return null; 
            }
        }
        foreach (var tile in Map.Walls)
        {
            Walls.SetTile(tile.Postion, GameManager.GM.TileManager.GetTile(tile.TileName));

            if (count >= 100)
            {
                count = 0;
                yield return null;
            }
        }
        foreach (var tile in Map.ForeGround)
        {
            Foreground.SetTile(tile.Postion, GameManager.GM.TileManager.GetTile(tile.TileName));

            if (count >= 100)
            {
                count = 0;
                yield return null;
            }
        }
        Name = filename; 

    }


    /// <summary>
    /// The default file path. 
    /// </summary>
    /// <returns></returns>
    public static string GetDefaultFilePath()
    {
        return $"{FileLoader.ModPath}/{MapFolder}"; 
    }
}

