using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EditorMapOptions : MonoBehaviour
{
    [MenuItem("Maps/SaveMap")]
    static void SaveMap()
    {
        var map = SceneAsset.FindObjectOfType<MapLoader>();
        //if (string.IsNullOrWhiteSpace(map.Name))
        //{
            var path = EditorUtility.SaveFilePanel("Save map", MapLoader.GetDefaultFilePath(), "", "map");
            var filename = Path.GetFileNameWithoutExtension(path);
            map.Name = filename;
       // }

        map.SaveMap(map.Name);
    }


    [MenuItem("Maps/LoadMap")]
    static void LoadMap()
    {
        var map = SceneAsset.FindObjectOfType<MapLoader>();
        var path = EditorUtility.OpenFilePanel("Load Map", MapLoader.GetDefaultFilePath(), "map");
        var filename = Path.GetFileNameWithoutExtension(path);
        map.StartCoroutine(map.LoadMap(filename, false));
    }

    [MenuItem("Maps/Clear")]
    static void ClearMap()
    {
        var map = SceneAsset.FindObjectOfType<MapLoader>();
        map.Foreground.ClearAllTiles();
        map.BackGround.ClearAllTiles();
        map.Walls.ClearAllTiles();
        map.Name = ""; 
    }


    //[MenuItem("Maps/PopulateTileManager")]
    //static void PopulateTileManager()
    //{

    //    var tileManager = SceneAsset.FindObjectOfType<TileManager>();
    //    tileManager.Tiles = new Dictionary<string, TileBase>(); 
    //    var tilebase = Resources.FindObjectsOfTypeAll<TileBase>(); 
    //    foreach(var tile in tilebase)
    //    {
    //        if (!tileManager.Tiles.ContainsKey(tile.name))
    //            tileManager.Tiles.Add(tile.name, tile); 
    //    }
    //}

    [MenuItem("Maps/ImportTiles")]
    static void LoadTilesIntoGame()
    {
        var tilemanager = SceneAsset.FindObjectOfType<TileManager>();
        tilemanager.StartCoroutine(tilemanager.LoadTiles(true));

    }

    [MenuItem("Maps/ImportSpritesheets")]
    static void ImportTiles()
    {
        var files = Directory.GetFiles($"{FileLoader.ModPath}/{TileManager.TilePath}");
        var tilemanager = SceneAsset.FindObjectOfType<TileManager>();
        tilemanager.StartCoroutine(tilemanager.LoadTiles(true));


        foreach (var file in files)
        {
            if (Path.GetExtension(file) != ".png")
                continue;
            var filename = Path.GetFileNameWithoutExtension(file);
            

            var resourcePath = $"./Assets/Resources/TilesSpritesheets/{filename}.png";

            if (!File.Exists(resourcePath))
                File.Copy(file, resourcePath);


            AssetDatabase.ImportAsset(resourcePath, ImportAssetOptions.ForceUpdate);
            
            AssetDatabase.Refresh();

            var myTexture = AssetDatabase.LoadAssetAtPath<Texture2D>($"Assets/Resources/TilesSpritesheets/{filename}.png");
            
            string path = AssetDatabase.GetAssetPath(myTexture);
            TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
            ti.isReadable = true;
            ti.spritePixelsPerUnit = 32;
            ti.filterMode = FilterMode.Point;
            ti.spriteImportMode = SpriteImportMode.Multiple; 
            List<SpriteMetaData> newData = new List<SpriteMetaData>();

            int SliceWidth = 32;
            int SliceHeight = 32;
            
            for (int i = 0; i <= myTexture.width; i += SliceWidth)
            {
                for (int j = 0; j <= myTexture.height; j += SliceHeight)
                {
                    SpriteMetaData smd = new SpriteMetaData();
                    smd.pivot = new Vector2(0.5f, 0.5f);
                    smd.alignment = 9;
                    smd.name = $"{filename}_{i}_{j}"; 
                    smd.rect = new Rect(i, j, SliceWidth, SliceHeight);

                    newData.Add(smd);
                }
            }

            ti.spritesheet = newData.ToArray();
            
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
        }

        AssetDatabase.Refresh();
        return; 
       
    }



}
