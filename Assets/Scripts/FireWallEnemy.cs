using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallEnemy : MonoBehaviour
{
    public float speed = 3f;
    public float slowDuration = 10f;
    public float slowFactor = 0.5f;
    public float distanceThreshold = 0.1f;
    public float minDistanceFromPlayer = 5f;
    public Transform playerTransform;

    private bool isSlowing = false;
    private float timeSinceSlow = 0f;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < minDistanceFromPlayer && !isSlowing)
        {
            isSlowing = true;
            timeSinceSlow = 0f;
        }

        if (isSlowing)
        {
            timeSinceSlow += Time.deltaTime;
            if (timeSinceSlow >= slowDuration)
            {
                isSlowing = false;
                timeSinceSlow = 0f;
            }
            else
            {
                CharacterMovement CharacterMovement = playerTransform.GetComponent<CharacterMovement>();
                CharacterMovement.moveVelocity = speed * slowFactor;
            }
        }

        if (!isSlowing && distanceToPlayer > distanceThreshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        CharacterMovement characterConCharacterMovementtroller = playerTransform.GetComponent<CharacterMovement>();
        //CharacterMovement.moveVelocity = speed;
    }
}