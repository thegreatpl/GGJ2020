using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

public static class FileLoader
{

    public static string ModPath = "./StreamingAssets/GGJ2020"; 

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
}

