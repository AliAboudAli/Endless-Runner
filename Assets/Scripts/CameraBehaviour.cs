using System.Collections;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    public bool Shake = false;
    public float duration = 1f;
    public float magnitude = 0.1f;

    void Start()
    {
        //Empty on start
    }

    void Update()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            Vector3 pos = new Vector3(player.transform.position.x, 0, -10);
            camera.transform.position = pos;
        }
        if (Shake)
        {
            Shake = false;
            StartCoroutine(ShakeCamera());
        }
    }

    public IEnumerator ShakeCamera()
    {
        Vector3 originalPosition = camera.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camera.transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        camera.transform.localPosition = originalPosition;
    }
}
