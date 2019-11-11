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
        Debug.Log(this.transform.GetChild(0).gameObject);
        
    }

    public void setPlatter(/* Platter platter */)
    {
        auto thisPlatterSprite = this.transfrom.GetChild(0).gameObject;
        thisPlatterSprite.Destroy();
    }

    private void OnMouseUp()
    {
        this.setPlatter();
    }
}
