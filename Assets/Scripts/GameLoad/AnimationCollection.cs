using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class AnimationCollection
{
    public string Name; 

    public List<AnimationDefine> Animations; 
}

[Serializable]
public class AnimationDefine
{
    public string Name;

    public Sprite[] Sprites; 
}