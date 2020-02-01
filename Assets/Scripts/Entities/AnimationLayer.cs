using System;
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
        transform.parent.GetComponent<SpriteAnimator>()?.AnimationLayers.Add(this); 
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
            var sprites = new Sprite[animation.Sprites.Length];
            for (int idx = 0; idx < animation.Sprites.Length; idx++)
                sprites[idx] = GameManager.GM.SpriteManager.GetSprite(animation.Sprites[idx]); 
            Animations.Add(animation.AnimationName, sprites); 
        }
    }
}

