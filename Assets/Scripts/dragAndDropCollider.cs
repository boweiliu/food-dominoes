using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dragAndDropCollider : MonoBehaviour
{

    private Vector3 initialHandlePosition;
    private Vector3 initialMousePosition;

    [SerializeField]
    new protected UnityEngine.Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 getMousePosition()
    {
       
        Vector3 screen = Input.mousePosition;
        screen.z = (camera.transform.position - transform.position).magnitude;
        Vector3 position = camera.ScreenToWorldPoint(screen);
        return position;
        
        // return Input.mousePosition;
    }


    private void OnMouseDown()
    {
        initialMousePosition = getMousePosition();
        initialHandlePosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 tempMousePosition = getMousePosition();
        Vector3 delta = initialMousePosition - tempMousePosition;
        //  delta.y = 0;
        delta.z = 0;
        delta.x = (float)(Mathf.Round(delta.x));
        // float offset = 0.75F;
        float grid = 1.5F;
        // delta.x -= offset;
        delta.x /= grid;
        delta.x = (float)(Mathf.Round(delta.x));
        delta.x *= grid;
        delta.y /= grid;
       //  delta.x += offset;
        delta.y = (float)(Mathf.Round(delta.y));
        delta.y *= grid;

        
        gameObject.transform.position = initialHandlePosition - delta;
    }   

}
