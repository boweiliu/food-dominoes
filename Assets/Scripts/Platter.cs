using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platter : ScriptableObject
{
    public FoodType[] Foods;

    public Platter()
    {
        Foods = new FoodType[4];
    }
}
