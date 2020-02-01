using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{

    public int AnimationRate = 10; 

    public string CurrentAnimation;

    int current = 0;

    int counter = 0; 

    public List<AnimationLayer> AnimationLayers;


    void Start()
    {
        counter = AnimationRate;

        CurrentAnimation = "IdleDown"; 

        //StartCoroutine(Animate()); 
    }

    void Update()
    {
        if (counter >= AnimationRate)
        {
            foreach (var layer in AnimationLayers)
                layer.SetAnimation(CurrentAnimation, current);

            current++;
            if (AnimationLayers.Count > 0 
                && AnimationLayers[0].Animations.ContainsKey(CurrentAnimation) 
                && AnimationLayers[0].Animations[CurrentAnimation].Length <= current)
                current = 0;

            counter = 0;
        }

        counter++;
    }

   


    public void SetAnimation(string animation)
    {
        if (CurrentAnimation == animation)
            return; 

        CurrentAnimation = animation;
        current = 0;
        counter = AnimationRate; 
    }

}
