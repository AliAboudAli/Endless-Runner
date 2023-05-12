using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffucltyController : MonoBehaviour
{
    public MapGenerator mapGen;
    public float speedIncreasePerSecond = 0.1f;
    public float heightIncreasePerSecond = 0.05f;

    private float timeElapsed = 0.0f;

    private void Start()
    {
        mapGen = GetComponent<MapGenerator>();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        float newSpeed = mapGen.camera.transform.position.x + (timeElapsed * speedIncreasePerSecond);
        mapGen.camera.transform.position = new Vector3(newSpeed, mapGen.camera.transform.position.y, mapGen.camera.transform.position.z);

        float newHeight = mapGen.currentHeight + (timeElapsed * heightIncreasePerSecond);
        mapGen.currentHeight = Mathf.RoundToInt(newHeight);
    }
}