using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Attribute Attribute; //Reference to Attribute script


    public Direction Direction; 
 
    void Awake() 
    {
         Attribute = GetComponent<Attribute>(); //Setup reference
    }

    public void MoveUp() //Move upwards
    {
        transform.position += new Vector3(0, Attribute.attributes.Speed);//  .Translate(Vector2.up * Attribute.attributes.Speed);
    }

    public void MoveDown()  //Move downwards
    {
        //transform.Translate(-Vector2.up * Attribute.attributes.Speed);
        transform.position += new Vector3(0, -Attribute.attributes.Speed);
    }

    public void MoveLeft() //Move left
    {
        transform.position += new Vector3( -Attribute.attributes.Speed, 0);
       // transform.Translate(-Vector2.right * Attribute.attributes.Speed);
    }

    public void MoveRight() //Move right
    {
        transform.position += new Vector3(Attribute.attributes.Speed, 0);

       // transform.Translate(Vector2.right * Attribute.attributes.Speed);
    }
}
