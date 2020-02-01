using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Attribute Attribute; //Reference to Attribute script

    Direction _direction;
    public Direction Direction
    {
        get { return _direction; }
        set
        {
            if (value == Direction.None && _direction != Direction.None)
            {
                FacingDirection = _direction;
            }
            else if (value != Direction.None)
                FacingDirection = value;

            _direction = value;
        }
    }

    public Direction FacingDirection;

    private void Start()
    {
         _direction = Direction.None;
        FacingDirection = Direction.Down; 
         Attribute = GetComponent<Attribute>(); //Setup reference
    }


    void Update()
    {
        switch (_direction)
        {
            case Direction.None:
                break;
            case Direction.Left:
                transform.position += new Vector3(-Attribute.attributes.Speed, 0) * Time.deltaTime ;
                break;
            case Direction.Up:
                transform.position += new Vector3(0, Attribute.attributes.Speed) * Time.deltaTime;
                break;
            case Direction.Right:
                transform.position += new Vector3(Attribute.attributes.Speed, 0) * Time.deltaTime;
                break;
            case Direction.Down:
                transform.position += new Vector3(0, -Attribute.attributes.Speed) * Time.deltaTime;
                break;
        }
    }


    
}