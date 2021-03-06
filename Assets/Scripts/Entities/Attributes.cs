﻿using System.Collections;
using System.Collections.Generic;
using System;
[Serializable]
public class Attributes
{
    /// <summary>
    /// How fast this entity. 
    /// </summary>
    public float Speed; 

    /// <summary>
    /// The maximum HP of an entity. 
    /// </summary>
    public int MaxHP; 

    /// <summary>
    /// Strength of the entity. 
    /// </summary>
    public int Strength; 

    /// <summary>
    /// The dexterity of the entity. 
    /// </summary>
    public int Dexterity;

    /// <summary>
    /// The int of the entity. 
    /// </summary>
    public int Intellect; 


    public Attributes Clone()
    {
        return new Attributes()
        {
            Dexterity = Dexterity,
            Intellect = Intellect,
            MaxHP = MaxHP,
            Speed = Speed,
            Strength = Strength
        };
    }
}
