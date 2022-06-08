using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text highScore;
    int score;
    Text scoreText;

    float timer;
    float maxTimer;
    public AudioSource Points;
    void Start()
    {
        highScore.text = "Hi:   " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");
        score = 0;
        scoreText = GetComponent<Text>();
        maxTimer = 0.1f;
        Points.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTimer)
        {
            score++;
            scoreText.text = score.ToString("00000");
            timer = 0;
            if (score % 100 == 0)
            {
                Points.Play();
                Time.timeScale += 0.1f;
            }

        }
        if (Time.timeScale == 0)
        {
            if (score > PlayerPrefs.GetInt("highscore", 0))
            {
                PlayerPrefs.SetInt("highscore", score);
                highScore.text = "Hi    " + PlayerPrefs.GetInt("highScore", 0).ToString("00000");
            }
        }
    }
}
