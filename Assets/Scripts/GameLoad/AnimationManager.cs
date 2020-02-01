using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    public const string AnimationFolder = "Animations"; 

    public List<AnimationCollection> Animations; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AnimationCollection GetAnimation(string name)
    {
        return Animations.FirstOrDefault(x => x.LayerName == name); 
    }


    public IEnumerator LoadAnimations()
    {
        int count = 0; 
        var files = Directory.GetFiles($"{FileLoader.ModPath}/{AnimationFolder}", "*.json"); 
        foreach(var file in files)
        {
            var fileCollection = FileLoader.LoadJson<AnimationFile>(file);
            Animations.AddRange(fileCollection.Collections);

            count++;

            if (count % 20 == 0)
                yield return null; 
        }
    }
}
