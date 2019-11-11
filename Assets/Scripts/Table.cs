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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void feedDish(FoodType food)
    {

    }

    public void setFoodRequest(FoodType[] foods)
    {

    }
}
