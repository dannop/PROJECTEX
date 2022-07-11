using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [SerializeField] GameObject lefttUpgradeOption;
    [SerializeField] GameObject rightUpgradeOption;

    [SerializeField] GameObject victoryContainer;
    [SerializeField] GameObject defeatContainer;

    static Transform playerTransform;
    static GameController gameController;
    static SpherePowerController spherePowerController;
    
    private float time = 0;
    private TextMeshPro lifeText;
    private TextMeshPro scoreText;
    private TextMeshPro timeText;

    private string getStringTime()
    {
        if (gameController.score <= gameController.GetTotalEnemies()) time += Time.deltaTime;
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

    private void UpdateUIData()
    {
        lifeText.text = gameController.life.ToString();
        scoreText.text = gameController.score.ToString();
        timeText.text = getStringTime();
    }

    private void VerifyEnd()
    {
        if (gameController.GetTotalEnemies() <= gameController.score)
        {
            victoryContainer.SetActive(true);
        }
        else if (gameController.life <= 0)
        {
            defeatContainer.SetActive(true);
            if (OVRInput.Get(OVRInput.Button.Any)) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void SelectUpgrade()
    {
        if (OVRInput.Get(OVRInput.Button.Left))
        {
            gameController.maxLife += 10;
            gameController.life = gameController.maxLife;
        }
        else if (OVRInput.Get(OVRInput.Button.Right))
        {
            if (spherePowerController != null)
            {
                spherePowerController.orbitDegreesPerSec += 10.0f;
            }
            gameController.life = gameController.maxLife;
        }
    }

    private void VerifyLevelUp()
    {
        if (spherePowerController == null)
        {
            GameObject power = GameObject.FindGameObjectWithTag("Power");
            if (power != null) spherePowerController = power.GetComponent<SpherePowerController>();
        } 

        if (gameController.GetPendingUpgrades() > 0)
        {
            lefttUpgradeOption.SetActive(true);
            rightUpgradeOption.SetActive(true);
            SelectUpgrade();
        } 
        else
        {
            lefttUpgradeOption.SetActive(false);
            rightUpgradeOption.SetActive(false);
        }
    }

    private void Update()
    {
        UpdateUIData();
        VerifyLevelUp();
        VerifyEnd();
    }
}
