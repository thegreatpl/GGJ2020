using UnityEngine;

public class EntityAttribute : MonoBehaviour
{
    public int CurrentHP;

    public Attributes Attributes;


    public EntityDefines EntityDefines;


    void Start()
    {
        GameManager.GM.EntityManager.Entities.Add(this); 
    }

    public void LoadEntity(EntityDefines entityDefines)
    {
        Attributes = entityDefines.Attributes.Clone();
        CurrentHP = Attributes.MaxHP;
        EntityDefines = entityDefines;

        var prefab = GameManager.GM.PrefabManager.GetPrefab("SpriteLayer"); 
        foreach(var layer in EntityDefines.EntityLayers)
        {
            var newLayer = Instantiate(prefab, transform); 
            newLayer.GetComponent<AnimationLayer>().AssignAnimation(GameManager.GM.AnimationManager.GetAnimation(layer.Layername));
            var spriteRend = newLayer.GetComponent<SpriteRenderer>();
            spriteRend.sortingOrder = layer.DrawLayer;
            spriteRend.color = layer.Color; 
        }

        transform.position = GameManager.GM.MapLoader.BackGround.CellToWorld(EntityDefines.SpawnLocation); 
    }

    void Update()
    {
        if (CurrentHP < 0)
        {
            OnDeath();
            Destroy(gameObject); 
        }
    }

    public int GetDamage()
    {
        return Attributes.Strength; 
    }


    public void DealDamage(int damage, string type)
    {
        CurrentHP -= damage; 
    }



    public void OnDeath()
    {
        var ondeath = EntityDefines.OnDeath; 

        foreach(var tile in ondeath.ChangeTiles)
        {
            var t = GameManager.GM.TileManager.GetTile(tile.TileName); 
             switch(tile.Layer)
            {
                case "Background":
                    GameManager.GM.MapLoader.BackGround.SetTile(tile.Postion, t);
                    break;
                case "Foreground":
                    GameManager.GM.MapLoader.Foreground.SetTile(tile.Postion, t);
                    break;
                case "Walls":
                    GameManager.GM.MapLoader.Walls.SetTile(tile.Postion, t);
                    break;
            }
        }

       var player = GameManager.GM.PlayerAttributes.Attributes;
        player.Dexterity += ondeath.ChangePlayerAttributes.Dexterity;
        player.Intellect += ondeath.ChangePlayerAttributes.Intellect;
        player.MaxHP += ondeath.ChangePlayerAttributes.MaxHP;
        GameManager.GM.PlayerAttributes.CurrentHP += ondeath.ChangePlayerAttributes.MaxHP; 
        player.Speed += ondeath.ChangePlayerAttributes.Speed;
        player.Strength += ondeath.ChangePlayerAttributes.Strength; 
    }

}