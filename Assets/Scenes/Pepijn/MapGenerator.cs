using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapGenerator : MonoBehaviour
{

    public GameObject floor;
    public GameObject roof;
    public GameObject module;
    public Module previousModule;
    public Module currentModule;
    public GameObject[] modules;
    public GameObject camera;
    public GameObject cameraSpawnModuleCheck;
    public Transform blockSpawnpoint;
    public int currentHeight;
    public int minModulesBeforeChange;
    public int TileStreak;
    public bool start;


    public void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GenerateModule();
        }
        start = false;
    }
    public void Update()
    {
        camera.transform.position += transform.right * Time.deltaTime * 10;
        CheckAndSpawnModule();
    }


    public void GenerateModule()
    {
        if (currentModule != null)
        {
            currentModule = Instantiate(module, currentModule.spawnBlockPoint).GetComponent<Module>();
            currentModule.gameObject.transform.parent = transform;
        }
        else
        {
            currentModule = Instantiate(module, blockSpawnpoint).GetComponent<Module>();
        }
        if (!start)
        {
            int x = Random.Range(0,2);
            Debug.Log(x);
            if (minModulesBeforeChange <= TileStreak && x == 1)
            {
                Debug.Log(x);
                if (currentHeight != 0 && currentHeight < 3) currentHeight = Random.Range(currentHeight - 1, currentHeight + 2);
                else if (currentHeight == 0 ){ currentHeight = Random.Range(currentHeight, currentHeight + 2); }
                else { currentHeight = Random.Range(currentHeight-3, currentHeight); }
                TileStreak = 0;
            }
            currentModule.buildModule(currentHeight);
        }
        TileStreak++;
    }

    public void CheckAndSpawnModule()
    {
        if ( currentModule.spawnBlockPoint.transform.position.x - (camera.transform.position.x +15) < 0 )
        {
            GenerateModule();
        }
        else
        {

        }
    }

}
