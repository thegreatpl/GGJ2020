using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Movement Movement; 

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<Movement>();    
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical"); 
        if (moveX <0 )
        {
            Movement.Direction = Direction.Left; 
            Movement.MoveLeft(); 
        }
        else if (moveX > 0)
        {
            Movement.Direction = Direction.Right;
            Movement.MoveRight(); 
        }

        if (moveY < 0)
        {
            Movement.Direction = Direction.Down;
            Movement.MoveDown(); 
        }
        else if (moveY > 0)
        {
            Movement.Direction = Direction.Up;
            Movement.MoveUp();
        }

        if (moveX == 0 && moveY == 0)
            Movement.Direction = Direction.None; 


    }
}
