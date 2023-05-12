using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MissileLauncher : MonoBehaviour
{
    // de bedoeling is dat de Missiles 3 tegelijk damage geven na mate van tijd door een for loop

    public GameObject missilePrefab;
    public GameObject player;
    public float missileSpeed = 20f;
    public float missileInterval = 10f;
    public float warningDuration = 3f;
    public Text MissileIncomingSetting;

    private float nextMissileTime = 0f;

    //gedurende tijd neemt hij damage door een for loop
    void Update()
    {
        if (Time.time > nextMissileTime)
        {
            StartCoroutine(FireMissiles());
            nextMissileTime = Time.time + missileInterval;
        }
    }

    IEnumerator FireMissiles()
    {
        // Laat een waarschuwing text zien
        MissileIncomingSetting.text = "Missiles incoming!";
        yield return new WaitForSeconds(warningDuration);
        MissileIncomingSetting.text = "";

        // Vuurt 3 missiles 
        for (int i = 0; i < 3; i++)
        {
            Vector3 missilePosition = new Vector3(Random.Range(player.transform.position.x + 20f, transform.position.x - 20f), Random.Range(-5f, 5f), 0f);
            GameObject missile = Instantiate(missilePrefab, missilePosition, Quaternion.identity);
            missile.GetComponent<Rigidbody2D>().velocity = (player.transform.position - missilePosition).normalized * missileSpeed;
        }
    }
}
