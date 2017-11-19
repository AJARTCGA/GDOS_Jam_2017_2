using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    float timer = 0;
    public bool drawGUI = false;
    public Text timerText, scoreText, finalScore;
    public GameObject gameOverPanel, player;
    public float maxTime = 60;

    void Start()
    {
        timer = maxTime;
    }

    void Update()
    {
        if (drawGUI)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString();
            scoreText.text = Score.getInstance().getScore().ToString();
            if (timer < 0)
            {
                timer = 0;
                finalScore.text = Score.getInstance().getScore().ToString();
                gameOverPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            }
        }
    }

    public void onReset()
    {
        SceneManager.LoadScene("scene copy");
    }

    public void Awake()
    {
        
        /*NPCColorSingleton.refresh();
        NPCCostumeSingleton.refresh();
        NPCHatSingleton.refresh();
        NPCFaceSingleton.refresh();
        TargetSelectionScript.refresh();
        //NavTargetSingleton.refresh();
        Score.refresh();*/
        
    }
}
