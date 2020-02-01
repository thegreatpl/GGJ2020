﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine; 

public class AnimationLayer : MonoBehaviour
{
    public string LayerName; 

    public SpriteRenderer Sprite;

    public Dictionary<string, Sprite[]> Animations = new Dictionary<string, Sprite[]>();

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>(); 
    }

    public void SetAnimation(string animation, int count)
    {

        if (Animations.ContainsKey(animation))
        {
            var current = Animations[animation];
            if (current.Length > count)
                Sprite.sprite = current[count]; 
        }
    }

    public void AssignAnimation(AnimationCollection animationCollection)
    {
        foreach(var animation in animationCollection.Animations)
        {
            Animations.Add(animation.Name, animation.Sprites); 
        }
    }
}

