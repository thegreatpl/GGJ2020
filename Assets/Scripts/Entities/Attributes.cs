using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]
public class Attributes
{
    public float Speed; //Variable for speed
    public int MaxHP; //Variable for MaxHP;
    public int Strength; //Variable for strength
    public int Dexterity; //Variable for dex
    public int Intellect; //Variable for int

}

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