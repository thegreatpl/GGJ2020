using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EditorMapOptions : MonoBehaviour
{
    [MenuItem("Maps/SaveMap")]
    static void SaveMap()
    {
        var map = SceneAsset.FindObjectOfType<MapLoader>();
        if (string.IsNullOrWhiteSpace(map.Name))
        {
            var path = EditorUtility.SaveFilePanel("Save map", MapLoader.GetDefaultFilePath(), "", "map");
            var filename = Path.GetFileNameWithoutExtension(path);
            map.Name = filename;
        }

        map.SaveMap(map.Name);
    }


    [MenuItem("Maps/LoadMap")]
    static void LoadMap()
    {
        var map = SceneAsset.FindObjectOfType<MapLoader>();
        var path = EditorUtility.OpenFilePanel("Load Map", MapLoader.GetDefaultFilePath(), "map");
        var filename = Path.GetFileNameWithoutExtension(path);
        map.StartCoroutine(map.LoadMap(filename));
        
    }

    [MenuItem("Maps/Clear")]
    static void ClearMap()
    {
        var map = SceneAsset.FindObjectOfType<MapLoader>();
        map.Foreground.ClearAllTiles();
        map.BackGround.ClearAllTiles();
        map.Walls.ClearAllTiles(); 
    }


    [MenuItem("Maps/PopulateTileManager")]
    static void PopulateTileManager()
    {

    }
}
