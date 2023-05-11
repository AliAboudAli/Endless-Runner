using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    public float playerStartingPosition;
    public float playerEndingPosition;
    public float gameTime = 0;
    bool alive = true;
    bool saved = false;
    // Start is called before the first frame update
    void Start()
    {
        playerStartingPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            gameTime += Time.deltaTime;
        }
    }
    public void saveEnd()
    {
        alive = false;
        playerEndingPosition = transform.position.x;
        float score = playerEndingPosition - playerStartingPosition;
        PlayerPrefs.SetFloat("newestScore", score);
        PlayerPrefs.SetFloat("newestTime", score);
        for (int i = 1; i <= 10; i++)
        {
            string currentCheck = "score" + i;
            float best = PlayerPrefs.GetFloat(currentCheck);
            if (score > best)
            {
                if (saved == false)
                {
                    saved = true;
                    for (int j = i; j + i > 10; j++)
                    {
                        PlayerPrefs.SetFloat("score" + i + j + 1, PlayerPrefs.GetFloat("score" + i + j ));
                    }
                    PlayerPrefs.SetFloat(currentCheck, score);
                    PlayerPrefs.SetFloat("time" + i, gameTime);
                }
            }
        }
        for (int i = 1; i <= 10; i++)
        {
            print(PlayerPrefs.GetFloat("score" + i) + " Score for " + i );
        }

    }
}
