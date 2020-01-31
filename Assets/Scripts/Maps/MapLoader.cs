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




    public void SaveMap(string filename)
    {
        Map = new Map()
        {
            BackGround = BackGround.GetAllTileData().ToList(),
            ForeGround = Foreground.GetAllTileData().ToList(),
            Walls = Walls.GetAllTileData().ToList()
        };

        FileLoader.SaveAsJson($"{FileLoader.ModPath}/{MapFolder}/{filename}.map", Map); 
    }

    public void LoadMap(string filename)
    {
        Map = FileLoader.LoadJson<Map>($"{FileLoader.ModPath}/{MapFolder}/{filename}.map"); 

    }
}

