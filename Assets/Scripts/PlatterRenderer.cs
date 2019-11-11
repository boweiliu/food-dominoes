using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatterRenderer : MonoBehaviour
{
    Platter platter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPlatter(/* Platter platter */)
    {
        GameObject thisPlatterSprite = this.transform.GetChild(0).gameObject;
        GameObject.Destroy(thisPlatterSprite);
    }

    private void OnMouseUp()
    {
        this.setPlatter();
    }
}
