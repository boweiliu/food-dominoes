using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridManager : MonoBehaviour
{
    public int rows;
    public float offsetX;
    public int columns;
    public float offsetY;
    public float delta;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = SnapToGridPosition(gameObject.transform.position);
    }

    Vector3 SnapToGridPosition(Vector3 p)
    {
        int x = (int)Mathf.Round((p.x-offsetX)/delta);
        int y = (int)Mathf.Round((p.y-offsetY)/delta);
        x = Math.Max(Math.Min(x,columns),0);
        y = Math.Max(Math.Min(y,rows),0);
        p.x = (float) x*delta+offsetX;
        p.y = (float) y*delta+offsetY;
        return p;
    }
}
