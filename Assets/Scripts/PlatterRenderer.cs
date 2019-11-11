using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatterRenderer : MonoBehaviour
{
    Platter platter;
    bool exploded = false;


    float[] xPos = { -.3f, .3f, .3f, -.3f };
    float[] yPos = { .3f, .3f, -.3f, -.3f };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPlatter(Platter platter)
    {
        this.platter = platter;

        for (int i = 0; i < 4; i++)
        {
            FoodType food = platter.Foods[i];
            if (food != null)
            {
                GameObject foodObj = Instantiate(food.prefab, transform);
                foodObj.transform.localPosition = new Vector3(xPos[i], yPos[i], -1.5f);
                foodObj.transform.localScale = new Vector3(0.3f, 0.3f);
            }
        }
    }

    private void placePlatter(/* Platter platter */)
    {
        GameObject thisPlatterSprite = this.transform.GetChild(0).gameObject;
        if (exploded == false)
        {
            GameObject.Destroy(thisPlatterSprite);
            exploded = true;
        }
    }

    private void OnMouseUp()
    {
        GameManager.Instance.endPlatterDrag(platter, transform.position);
        Destroy(gameObject);
    }
}
