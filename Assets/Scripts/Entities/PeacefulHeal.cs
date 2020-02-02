using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeacefulHeal : MonoBehaviour
{
    public List<string> HealingTiles = new List<string>();

    public int HealingUp = 500;

    public EntityAttribute EntityAttribute; 

    GameManager GameManager;

    int healCur = 0; 
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameManager.GM;
        EntityAttribute = GetComponent<EntityAttribute>(); 
    }

    // Update is called once per frame
    void Update()
    {
        var tile = GameManager.MapLoader.BackGround.GetTile(GameManager.MapLoader.BackGround.WorldToCell(transform.position));
        if (HealingTiles.Contains(tile.name))
        {
            healCur++;
            if (healCur >= HealingUp)
            {
                healCur = 0;
                EntityAttribute.CurrentHP++;
                if (EntityAttribute.CurrentHP > EntityAttribute.Attributes.MaxHP)
                    EntityAttribute.CurrentHP = EntityAttribute.Attributes.MaxHP;
            }
        }
        else
            healCur = 0; 
    }
}
