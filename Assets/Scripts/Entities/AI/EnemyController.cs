using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameManager GameManager; 

    public Movement Movement;

    public int SightRange = 10;


    int _wanderChange = 0; 

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<Movement>();
        GameManager = GameManager.GM; 
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = GameManager.PlayerAttributes?.transform;
        if (playerPos == null)
            return; 

        var distance = Vector3.Distance(transform.position, playerPos.position);
        if (distance < 2)
        {        
            var heading = playerPos.position - transform.position; 
            var direction = GetDirection(heading);
            Movement.FacingDirection = direction;
            Movement.Attack(); 
        }
        else if (distance < SightRange)
        {
            var heading = playerPos.position - transform.position;
            var direction = GetDirection(heading);
            Movement.Direction = direction; 
        }
        else
        {
            if (_wanderChange > 20)
            {
                //wander. 
                var chance = Random.value;
                if (chance <= 0.1f)
                {
                    Movement.Direction = Direction.None;
                }
                else if (chance <= 0.15f)
                {
                    Movement.Direction = Direction.Up;
                }
                else if (chance <= 0.2f)
                {
                    Movement.Direction = Direction.Left;
                }
                else if (chance <= 0.25f)
                {
                    Movement.Direction = Direction.Right;
                }
                else if (chance <= 0.3f)
                {
                    Movement.Direction = Direction.Down;
                }

                _wanderChange = 0;
            }
            else
                _wanderChange++; 
        }

    }


    Direction GetDirection(Vector3 heading)
    {
        var yPosi = heading.y > 0 ? heading.y : heading.y * -1;
        var xposi = heading.x > 0 ? heading.x : heading.x * -1;
        if (xposi >= yPosi && heading.x > 0)
        {
            return Direction.Right; 
        }
        if (xposi >= yPosi)
        {
            return Direction.Left; 
        }
        if (heading.y > 0)
        {
            return Direction.Up; 
        }
        return Direction.Down;       
    }
}
