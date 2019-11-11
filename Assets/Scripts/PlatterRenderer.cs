using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatterRenderer : MonoBehaviour
{
    Platter platter;
    bool exploded = false;

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

        //TODO: Update Graphics
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
