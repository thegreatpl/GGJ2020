using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class EntityDefines
{
    /// <summary>
    /// The spawn location of this entity. 
    /// </summary>
    public Vector3Int SpawnLocation; 

    /// <summary>
    /// Attributes of this entity. 
    /// </summary>
    public Attributes Attributes;

    /// <summary>
    /// Layers of this entity. 
    /// </summary>
    public List<EntityLayer> EntityLayers;

    /// <summary>
    /// What happens when this entity dies. 
    /// </summary>
    public OnDeath OnDeath; 

}

[Serializable]
public class EntityLayer
{
    public int DrawLayer;

    public string Layername;

    public Color Color; 
}

[Serializable]
public class OnDeath
{
    /// <summary>
    /// List of all tiles that will be changed when this entity dies. 
    /// </summary>
    public List<TileData> ChangeTiles;

    /// <summary>
    /// On the death of this entity, change these player attributes. 
    /// </summary>
    public Attributes ChangePlayerAttributes; 


}