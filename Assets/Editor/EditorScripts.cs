using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EditorScripts : MonoBehaviour
{
    [MenuItem("ModCreation/CreateAnimations")]
    static void CreateAnimations()
    {
        var fileCollection = new AnimationFile();
        fileCollection.Collections = new List<AnimationCollection>(); 
        var files = Directory.GetFiles($"{FileLoader.ModPath}/{SpriteManager.SpritePath}", "*.png", SearchOption.AllDirectories);
        foreach(var file in files)
        {
            var filename = Path.GetFileNameWithoutExtension(file); 
            var collection = new AnimationCollection();
            collection.LayerName = Path.GetFileNameWithoutExtension(file);
            collection.Animations = new List<AnimationDefine>()
            {
                new AnimationDefine()
                {
                    AnimationName = "WalkRight", Sprites = new string[]
                    {
                        $"{filename}_0_9",
                        $"{filename}_1_9",
                        $"{filename}_2_9",
                        $"{filename}_8_9",
                        $"{filename}_3_9",
                        $"{filename}_4_9",
                        $"{filename}_5_9",
                        $"{filename}_6_9",
                        $"{filename}_7_9",
                    }
                },
                new AnimationDefine()
                {
                    AnimationName = "WalkLeft", Sprites = new string[]
                    {
                        $"{filename}_0_11",
                        $"{filename}_1_11",
                        $"{filename}_2_11",
                        $"{filename}_3_11",
                        $"{filename}_4_11",
                        $"{filename}_5_11",
                        $"{filename}_6_11",
                        $"{filename}_7_11",
                        $"{filename}_8_11",
                    }
                },
                new AnimationDefine()
                {
                    AnimationName = "WalkUp", Sprites = new string[]
                    {
                        $"{filename}_0_12",
                        $"{filename}_1_12",
                        $"{filename}_2_12",
                        $"{filename}_3_12",
                        $"{filename}_4_12",
                        $"{filename}_5_12",
                        $"{filename}_6_12",
                        $"{filename}_7_12",
                        $"{filename}_8_12",
                    }
                },
                new AnimationDefine()
                {
                    AnimationName = "WalkDown", Sprites = new string[]
                    {
                        $"{filename}_0_10",
                        $"{filename}_1_10",
                        $"{filename}_2_10",
                        $"{filename}_3_10",
                        $"{filename}_4_10",
                        $"{filename}_5_10",
                        $"{filename}_6_10",
                        $"{filename}_7_10",
                        $"{filename}_8_10",
                    }
                },
                 new AnimationDefine()
                 {
                    AnimationName = "IdleRight", Sprites = new string[]
                    {     
                        $"{filename}_0_9",
                    }
                 },
                 new AnimationDefine()
                 {
                    AnimationName = "IdleLeft", Sprites = new string[]
                    {
                        $"{filename}_0_11",
                    }
                 },
                 new AnimationDefine()
                 {
                    AnimationName = "IdleUp", Sprites = new string[]
                    {
                        $"{filename}_0_12",
                    }
                 },
                 new AnimationDefine()
                 {
                    AnimationName = "IdleDown", Sprites = new string[]
                    {
                        $"{filename}_0_10",
                    }
                 },
                 //5-8
                 new AnimationDefine()
                 {
                     AnimationName = "AttackLeft", Sprites = new string[]
                     {
                         $"{filename}_0_7",
                         $"{filename}_1_7",
                         $"{filename}_2_7",
                         $"{filename}_3_7",
                         $"{filename}_4_7",
                         $"{filename}_5_7",
                     }
                 },
                 new AnimationDefine()
                 {
                     AnimationName = "AttackRight", Sprites = new string[]
                     {
                         $"{filename}_0_5",
                         $"{filename}_1_5",
                         $"{filename}_2_5",
                         $"{filename}_3_5",
                         $"{filename}_4_5",
                         $"{filename}_5_5",
                     }
                 },
                 new AnimationDefine()
                 {
                     AnimationName = "AttackUp", Sprites = new string[]
                     {
                         $"{filename}_0_8",
                         $"{filename}_1_8",
                         $"{filename}_2_8",
                         $"{filename}_3_8",
                         $"{filename}_4_8",
                         $"{filename}_5_8",
                     }
                 },
                 new AnimationDefine()
                 {
                     AnimationName = "AttackDown", Sprites = new string[]
                     {
                         $"{filename}_0_6",
                         $"{filename}_1_6",
                         $"{filename}_2_6",
                         $"{filename}_3_6",
                         $"{filename}_4_6",
                         $"{filename}_5_6",
                     }
                 },
            };
            fileCollection.Collections.Add(collection); 
        }
        FileLoader.SaveAsJson($"{FileLoader.ModPath}/{AnimationManager.AnimationFolder}/animations.json", fileCollection); 
    }

  //  [MenuItem("ModCreation/RenameFiles")]
    static void RenameFiles()
    {
        var files = Directory.GetFiles($"{FileLoader.ModPath}/{SpriteManager.SpritePath}", "*.png", SearchOption.AllDirectories);
        foreach(var file in files)
        {
            var filename = Path.GetFileName(file);
            var directory = Path.GetDirectoryName(file);

            string dirName = new DirectoryInfo(directory).Name;

            File.Move(file, $"{directory}/{dirName}_{filename}");
        }
    }


    [MenuItem("ModCreation/CreateEntityJson")]
    static void CreateEntityJson()
    {
        EntityDefines entityDefines =
            new EntityDefines()
            {
                Attributes = new Attributes()
                {
                    Strength = 1,
                    MaxHP = 10,
                    Speed = 2,
                    Dexterity = 1,
                    Intellect = 1
                },
                EntityLayers = new List<EntityLayer>()
            {
                new EntityLayer() {DrawLayer = 1, Layername = "male_skeleton", Color= Color.white},
            },
                SpawnLocation = new Vector3Int(0, 0, 0),
                OnDeath = new OnDeath() { ChangeTiles = new List<TileData>()
                {
                    new TileData(){Layer = "Background", Postion = new Vector3Int(1, 1, 0), TileName = "Assorted Terrain 1_256_352"},         
                    new TileData(){Layer = "Background", Postion = new Vector3Int(1, 2, 0), TileName = "Assorted Terrain 1_256_352"},
                    new TileData(){Layer = "Background", Postion = new Vector3Int(1, 3, 0), TileName = "Assorted Terrain 1_256_352"},
                    new TileData(){Layer = "Background", Postion = new Vector3Int(1, 4, 0), TileName = "Assorted Terrain 1_256_352"},
                    new TileData(){Layer = "Background", Postion = new Vector3Int(1, 5, 0), TileName = "Assorted Terrain 1_256_352"},
                    new TileData(){Layer = "Background", Postion = new Vector3Int(1, 6, 0), TileName = "Assorted Terrain 1_256_352"},
                },
                                        
                ChangePlayerAttributes = new Attributes() }
            };
        FileLoader.SaveAsJson($"{FileLoader.ModPath}/Maps/entity.json", entityDefines); 
        
    }

    [MenuItem("ModCreation/CreateGameInit")]
    static void CreateGameInit()
    {
        var gameinit = new GameInit()
        {
            HealingTiles = new List<string>()
            {
                "Assorted Terrain 2_32_416",
                "Assorted Terrain 2_0_352",
                "Assorted Terrain 2_32_352",
                "Assorted Terrain 2_64_352"
            },
            Levels = new LevelInfo[1] { new LevelInfo { LevelFile = "wasteland", SpawnLoc = new Vector3Int(0, 0, 0) } },
            PlayerDefines = new EntityDefines()
            {
                Attributes = new Attributes()
                {
                    Strength = 2,
                    MaxHP = 100,
                    Speed = 3,
                    Dexterity = 1,
                    Intellect = 1
                },
                EntityLayers = new List<EntityLayer>()
                {
                    new EntityLayer() { DrawLayer = 1, Layername = "female_black", Color = Color.white },
                    new EntityLayer() { DrawLayer = 2, Layername = "female_bangslong2", Color = Color.red },
                    new EntityLayer() { DrawLayer = 3, Layername = "female_pants", Color = Color.blue },
                    new EntityLayer() { DrawLayer = 4, Layername = "female_chainmail", Color = Color.white }
                },
                SpawnLocation = new Vector3Int(0, 0, 0),
                OnDeath = new OnDeath() { ChangeTiles = new List<TileData>(), ChangePlayerAttributes = new Attributes() }
            }
        };

        FileLoader.SaveAsJson($"{FileLoader.ModPath}/Game.init", gameinit); 
    }
}
