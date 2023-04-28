using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float timer = 60f;
    public Text timerText;
    private int setTimerInt;

    private GameStateManager gameStateManager; 
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0){
            timer -= Time.deltaTime;
        } else {
            timer = 0;
            gameStateManager.GameOver(); 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Title");
            }
        }

        setTimerInt = (int)timer;

        timerText.text = setTimerInt.ToString();
    }
}
