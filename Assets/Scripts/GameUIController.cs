using System;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    static Transform playerTransform;
    static GameController gameController;
    
    private float time = 0;
    private TextMeshPro lifeText;
    private TextMeshPro scoreText;
    private TextMeshPro timeText;

    private string getStringTime()
    {
        if (gameController.score <= gameController.maxScore) time += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        return string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }

    private void Awake()
    {
        if (playerTransform == null) playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (gameController == null) gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
        lifeText = GameObject.Find("LifeText").GetComponent<TextMeshPro>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        timeText = GameObject.Find("TimerText").GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        lifeText.text = gameController.life.ToString();
        scoreText.text = gameController.score.ToString();
        timeText.text = getStringTime();
    }
}
