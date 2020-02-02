using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public static class FileLoader
{
    public delegate void OnAudioLoaded(AudioClip audioClip);  


    public static string ModPath = "./Assets/StreamingAssets/GGJ2020";

    public static string ModPathWebRequest = "/Assets/StreamingAssets/GGJ2020";

    /// <summary>
    /// Loads an object into data from a json file. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="file"></param>
    /// <returns></returns>
    public static T LoadJson<T> (string file)
    {
        try
        { 
            var data = File.ReadAllText(file);

            T item;
            item = JsonUtility.FromJson<T>(data);
            return item; 

        }
        catch(Exception e)
        {
            Debug.LogError(e.Message); 
            throw; 
        }
    }


    public static void SaveAsJson(string file, object obj)
    {
        try
        {
            var data = JsonUtility.ToJson(obj, true);
            File.WriteAllText(file, data);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            throw; 
        }
    }


    public static Texture2D LoadTexture2D(string file)
    {
        if (File.Exists(file))
        {
            var filedata = File.ReadAllBytes(file);
            var texture = new Texture2D(2, 2);
            texture.LoadImage(filedata);
            return texture; 
        }
        throw new Exception($"File {file} does exist"); 
    }



    public static IEnumerator LoadAudio(string filePath, OnAudioLoaded OnComplete)
    {
        AudioType type; 
        switch(Path.GetExtension(filePath).ToLower())
        {
            case ".wav":
                type = AudioType.WAV;
                break; 
            default:
                Debug.LogError("Audio extention not recognised"); 
                yield break; 
        }


        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(filePath, type);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.LogWarning(request.error + "\n" + filePath);
        }
        else
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
            clip.name = Path.GetFileNameWithoutExtension(filePath);
            // Assign to audio source here.

            OnComplete(clip); 
        }
    }
}

