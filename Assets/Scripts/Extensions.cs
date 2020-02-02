using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;
using UnityEngine;

public static partial class Extensions
{
    /// <summary>
    /// Gets all the tiles as tiledata. 
    /// </summary>
    /// <param name="tilemap"></param>
    /// <returns></returns>
    public static IEnumerable<TileData> GetAllTileData(this Tilemap tilemap)
    {
        foreach(var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                var tile = tilemap.GetTile(pos);
                yield return new TileData()
                {
                    Postion = pos,
                    TileName = tile.name, 
                    Layer = tilemap.name
                }; 
            }
        }
    }


    public static T RandomElement<T>(this IEnumerable<T> ts)
    {
        return ts.ElementAt(UnityEngine.Random.Range(0, ts.Count())); 
    }
}

