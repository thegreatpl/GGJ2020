using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]
public class Attributes
{
    public float Speed; //Variable for speed
    int MaxHP; //Variable for MaxHP;
    int Strength; //Variable for strength
    int Dexterity; //Variable for dex
    int Intellect; //Variable for int



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