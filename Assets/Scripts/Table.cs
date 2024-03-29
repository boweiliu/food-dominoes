﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    FoodType[] RequestedFood;
    bool[] fed;

    GameObject[] FoodObjects;

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
                FoodObjects[i].SetActive(false);
                return;
            }
        }
        //Do we care if they're fed something they don't want to eat?
    }

    public void setFoodRequest(FoodType[] foods)
    {
        RequestedFood = foods;
        fed = new bool[dishCount];
        FoodObjects = new GameObject[dishCount];
        int numFoods = foods.Length;
        float centerOffset = (numFoods - 1.0f) / 2.0f;

        for (int i = 0; i < numFoods; i++)
        {
            FoodType food = RequestedFood[i];
            GameObject foodObj = Instantiate(food.prefab, transform);
            FoodObjects[i] = foodObj;

  

            //TODO: Properly do table stuff so we can make this function nice and neat
            foodObj.transform.localPosition = new Vector3((i - centerOffset) / 3 / 16, (i - centerOffset) / 3 / 16, -2);
        }
    }


}
