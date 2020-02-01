using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class AnimationFile
{
    public List<AnimationCollection> Collections; 
}

[Serializable]
public class AnimationCollection
{
    public string LayerName; 

    public List<AnimationDefine> Animations; 
}

[Serializable]
public class AnimationDefine
{
    public string AnimationName;

    public string[] Sprites; 
}