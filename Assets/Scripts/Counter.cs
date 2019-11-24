using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Serving counter holds and requests for new platters
// Manages initial placement of platters
public class Counter : MonoBehaviour
{
    public int platterGoal;

    [SerializeField]
    private GameObject platterObject;

    private GameObject[] platters;
    // Start is called before the first frame update
    void Start()
    {
        platters = new GameObject[platterGoal];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<platterGoal; i++)
        {
            if (!platters[i])
            {
                GameObject platter = Instantiate(platterObject);
                platters[i] = platter;
                PlatterRenderer render = platter.GetComponent<PlatterRenderer>();
                render.setPlatter(GameManager.Instance.newPlatter());

                platter.transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y + i * 1.5f
                );
            }
        }
    }
}
