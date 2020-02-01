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
}
