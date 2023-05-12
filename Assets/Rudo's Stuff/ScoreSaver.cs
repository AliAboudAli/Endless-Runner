using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreSaver : MonoBehaviour
{
    public bool inGame = true;
    public float playerStartingPosition;
    public float playerEndingPosition;
    public float gameTime = 0;
    bool alive = true;
    bool saved = false;
    public TMP_Text[] scoreText;
    public TMP_Text[] timeText;
    // Start is called before the first frame update
    void Start()
    {
/*        for (int j = 0; j <= 10; j++)
        {
            PlayerPrefs.SetFloat("score" + j , 0);
        }*/
        if (inGame)
        {
            playerStartingPosition = transform.position.x;
        }
        for (int i = 0; i < scoreText.Length; i++)
        {
            int number = i + 1;
            scoreText[i].text = PlayerPrefs.GetFloat("score" + number).ToString();
            timeText[i].text = PlayerPrefs.GetFloat("time" + number).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alive && inGame)
        {
            gameTime += Time.deltaTime;
        }
    }
    public void saveEnd()
    {
        if (alive)
        {
            alive = false;
            playerEndingPosition = transform.position.x;
            float score = playerEndingPosition - playerStartingPosition;
            PlayerPrefs.SetFloat("newestScore", score);
            PlayerPrefs.SetFloat("newestTime", score);
            print(score + " Score");
            for (int i = 1; i <= 10; i++)
            {
                float best = PlayerPrefs.GetFloat("score" + i);
                if (score > best)
                {
                    if (saved == false)
                    {
                        saved = true;
                        for (int j = 0; j + i < 10; j++)
                        {
                            int number = 10 - (i + j);
                            int number2 = (number + 1);
                            PlayerPrefs.SetFloat("score" + number2, PlayerPrefs.GetFloat("score" + number));
                            PlayerPrefs.SetFloat("time" + number2, PlayerPrefs.GetFloat("time" + number));
                        }
                        PlayerPrefs.SetFloat("score" + i, score);
                        PlayerPrefs.SetFloat("time" + i, gameTime);
                    }
                }
            }
            for (int i = 1; i <= 10; i++)
            {
                print(PlayerPrefs.GetFloat("score" + i) + " Score for " + i );
            }
            for (int i = 1; i <= 10; i++)
            {
                print(PlayerPrefs.GetFloat("time" + i) + " Time for " + i);
            }
        }

    }
}
