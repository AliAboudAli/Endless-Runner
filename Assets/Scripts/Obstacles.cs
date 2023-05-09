using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float Motions = 1f;

    private float initialY;

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * moveSpeed) * Motions;
        transform.position = new Vector3(transform.position.x, initialY + yOffset, transform.position.z);

    }
}
    

