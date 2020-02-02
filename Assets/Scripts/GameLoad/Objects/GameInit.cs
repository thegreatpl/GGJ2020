using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class GameInit
{
    public string BackGroundMusic; 

    public LevelInfo[] Levels;

    public EntityDefines PlayerDefines;

    public List<string> HealingTiles; 
}

[Serializable]
public class LevelInfo
{
    public string LevelFile;

    public Vector3Int SpawnLoc; 
}

