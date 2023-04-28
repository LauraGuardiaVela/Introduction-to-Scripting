﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 1

    [HideInInspector]
    public int sheepSaved; // 2

    [HideInInspector]
    public int sheepDropped; // 3

    public int sheepDroppedBeforeGameOver; // 4
    public SheepSpawner sheepSpawner; // 5
    public TimerController timerController;
    
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
        
    }
    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }

    public void GameOver()
    {
        sheepSpawner.canSpawn = false; // 1
        sheepSpawner.DestroyAllSheep(); // 2
        UIManager.Instance.ShowGameOverWindow();
    }
    public void DroppedSheep()
    {
        UIManager.Instance.UpdateSheepDropped();
        sheepDropped++; // 1

        if (sheepDropped == sheepDroppedBeforeGameOver) // 2
        {
            GameOver();
        }
    }
 
}