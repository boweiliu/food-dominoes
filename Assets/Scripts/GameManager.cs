using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get;
        private set;
    }

    Table[][] tableGrid;

    [SerializeField]
    private GameObject TablePrefab;

    [SerializeField]
    private FoodType[] FoodOptions;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance)
        {
            Destroy(this);
        }
        Instance = this;

        //Possibly generate table grid here


    }
    
    public void endPlatterDrag(Vector3 position)
    {
        //translate from world space into game space
    }

    // x and y are the coordinates, 1 indexed
    // (since <1,1> will hit <0,0> <0,1> <1,0> and <1,1>)
    private void servePlatter(Platter platter, int x, int y)
    {

    }

    public Platter newPlatter()
    {
        Platter platter =  new Platter();
        return platter;
    }

    public void finishTable(Table table)
    {
        int requestCount = 4;
        FoodType[] requests = new FoodType[requestCount];
        for(int i = 0; i < requestCount; i++)
        {
            requests[i] = FoodOptions[(int)Random.Range(0, FoodOptions.Length - 1)];
        }
        table.setFoodRequest(requests);
    }
}
