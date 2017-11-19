using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float timer = 0;
    public Text timerText, scoreText, finalScore;
    public GameObject gameOverPanel;
    public float maxTime = 60;
	void Start ()
    {
        timer = maxTime;
	}
	
	void Update ()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
        scoreText.text = Score.getInstance().getScore().ToString();
        if(timer < 0)
        {
            timer = 0;
            finalScore.text = Score.getInstance().getScore().ToString();
            gameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
	}

    public void onReset()
    {
        Debug.Log("Hit!");
    }
}
