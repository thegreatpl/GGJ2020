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

    public string QueuedAnimation { get; protected set; }

    void Start()
    {
        counter = AnimationRate;

        CurrentAnimation = "IdleDown";
        QueuedAnimation = null; 
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
            {
                current = 0;
                if (QueuedAnimation != null)
                {
                    CurrentAnimation = QueuedAnimation;
                    QueuedAnimation = null; 
                }
            }

            counter = 0;
        }

        counter++;
    }

   


    public void SetAnimation(string animation)
    {
        if (CurrentAnimation == animation)
            return; 

        if (QueuedAnimation != null)
        {
            QueuedAnimation = animation; 
        }

        CurrentAnimation = animation;
        current = 0;
        counter = AnimationRate; 
    }


    public void QueueAnimtiona(string animation)
    {
        QueuedAnimation = animation; 
    }

}
