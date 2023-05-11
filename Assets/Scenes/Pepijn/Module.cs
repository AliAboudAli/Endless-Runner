using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public GameObject floor;
    public GameObject roof;
    public Transform spawnBlockPoint;
    public MapGenerator mapGen;

    public void buildModule(int height)
    {
        floor.transform.position += transform.up * height;
    }

    public void Awake()
    {
        GetMapGen();
    }

    public void Update()
    {
        DeleteCheck();
    }

    public void GetMapGen()
    {
        mapGen = GameObject.FindWithTag("mapGen").GetComponent<MapGenerator>();
    }

    public void DeleteCheck()
    {
        if (mapGen.camera.transform.position.x - transform.position.x > 20)
        {
            Destroy(this.gameObject);
            return;
        }
    }

}
