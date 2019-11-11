using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    FoodType[] RequestedFood;
    bool[] fed;

    public int dishCount
    {
        get
        {
            return RequestedFood.Length;
        }
    }

    public void feedDish(FoodType food)
    {
        for(int i = 0; i < dishCount; i++)
        {
            if(!fed[i] && RequestedFood[i] == food)
            {
                fed[i] = true;
                //Update Visuals
                return;
            }
        }
        //Do we care if they're fed something they don't want to eat?
    }

    public void setFoodRequest(FoodType[] foods)
    {
        RequestedFood = foods;
        fed = new bool[dishCount];

        //Update Visuals
    }
}
