using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Map
{
    public List<TileData> BackGround;

    public List<TileData> Walls;

    public List<TileData> ForeGround;

    /// <summary>
    /// List of entities who spawn in on this level. 
    /// </summary>
    public List<EntityDefines> Entities; 

}

