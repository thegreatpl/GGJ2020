using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Attribute Attribute; //Reference to Attribute script
 
    void Awake() 
    {
         Attribute = GetComponent<Attribute>(); //Setup reference
    }

    public void MoveUp() //Move upwards
    {
        transform.Translate(Vector2.up * Attribute.attributes.Speed);
    }

    public void MoveDown()  //Move downwards
    {
        transform.Translate(-Vector2.up * Attribute.attributes.Speed);
    }

    public void MoveLeft() //Move left
    {
        transform.Translate(-Vector2.right * Attribute.attributes.Speed);
    }

    public void MoveRight() //Move right
    {
        transform.Translate(Vector2.right * Attribute.attributes.Speed);
    }
}
