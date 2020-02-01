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

        CurrentAnimation = "WalkLeft"; 

        StartCoroutine(Animate()); 
    }

    private IEnumerator Animate()
    {
        while(true)
        {
            if (counter >= AnimationRate)
            {
                foreach (var layer in AnimationLayers)
                    layer.SetAnimation(CurrentAnimation, current); 

                current++;
                if (AnimationLayers[0].Animations[CurrentAnimation].Length <= current)
                    current = 0; 

                counter = 0; 
            }

            counter++; 
            yield return null; 
        }
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
