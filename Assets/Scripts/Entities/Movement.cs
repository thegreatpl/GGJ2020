using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Attributes attributes; //Reference to Attributes script
 
    void Awake() 
    {
        Attributes attributes = GetComponent<Attributes>(); //Setup reference
    }

    void MoveUp() //Move upwards
    {
        transform.Translate(Vector2.up * attributes.Speed);
    }

    void MoveDown()  //Move downwards
    {
        transform.Translate(-Vector2.up * attributes.Speed);
    }

    void MoveLeft() //Move left
    {
        transform.Translate(-Vector2.right * attributes.Speed);
    }

    void MoveRight() //Move right
    {
        transform.Translate(Vector2.right * attributes.Speed);
    }
}
