using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine; 

public class AnimationLayer : MonoBehaviour
{
    public Sprite Sprite;

    public Dictionary<string, Sprite[]> Animations = new Dictionary<string, Sprite[]>();

    void Start()
    {
        Sprite = GetComponent<Sprite>(); 
    }

    public void SetAnimation(string animation, int count)
    {
        if (Animations.ContainsKey(animation))
        {
            var current = Animations[animation];
            if (current.Length > count)
                Sprite = current[count]; 
        }
    }


}

