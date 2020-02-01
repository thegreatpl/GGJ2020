using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine; 

[Serializable]
public class TileData
{
    /// <summary>
    /// The location of this tile. 
    /// </summary>
    public Vector3Int Postion;

    /// <summary>
    /// The name of the tile that is in this position. 
    /// </summary>
    public string TileName;

    /// <summary>
    /// Layer that this tile is being put on. 
    /// </summary>
    public string Layer; 
}

