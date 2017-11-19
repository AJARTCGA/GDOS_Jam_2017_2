using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float timer = 0;
    public Text timerText, scoreText;
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
	}
}
