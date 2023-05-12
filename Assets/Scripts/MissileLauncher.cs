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
    public TMP_Text MissileIncomingSetting;
    public Transform firepoint;
    private float nextMissileTime = 0f;
    public int amountOfMissles;

    private void Start()
    {
        player = GameObject.Find("Player");
        MissileIncomingSetting = GameObject.Find("MissileText").GetComponent<TMP_Text>();
    }
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
        for (int i = 0; i < amountOfMissles; i++)
        {
            GameObject missile = Instantiate(missilePrefab, firepoint.position, Quaternion.identity);
            missile.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * missileSpeed;
            missile.GetComponent<MissleScript>().target = player.transform;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
