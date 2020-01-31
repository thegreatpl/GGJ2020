using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    /// <summary>
    /// list of all prefabs in the game. 
    /// </summary>
    public List<GameObject> Prefabs; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject GetPrefab(string name)
    {
        var prefab = Prefabs.FirstOrDefault(x => x.name == name);
        return prefab; 
    }
}
