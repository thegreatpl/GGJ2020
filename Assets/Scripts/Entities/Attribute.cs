using UnityEngine;

public class Attribute : MonoBehaviour
{
    public int CurrentHP;

    public Attributes attributes;

    public void AssignAttributes(Attributes attribute)
    {
        attribute = attributes;
        CurrentHP = attribute.MaxHP;

    }



}