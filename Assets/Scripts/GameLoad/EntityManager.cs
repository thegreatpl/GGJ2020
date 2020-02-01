using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{

    public List<EntityAttribute> Entities; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Entities.RemoveAll(x => x == null); 
    }

    /// <summary>
    /// Destroys all game objects of type. 
    /// </summary>
    public void CullEntities()
    {
        foreach(var entity in Entities)
        {
            Destroy(entity.gameObject); 
        }
    }
}
