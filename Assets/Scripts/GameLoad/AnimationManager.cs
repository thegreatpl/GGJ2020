using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

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
        return Animations.FirstOrDefault(x => x.Name == name); 
    }
}
