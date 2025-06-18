
using System;
using TMPro;
using UnityEngine;

public class GameManager : SingletonPersistent<GameManager>
{
    
    private bool isGameRunning = false;
    private bool isPaused = false;
    //[SerializeField] GameData gameData;
 

    private void Start()
    {
        //databaseHandler = GetComponent<DatabaseHandler>();
        // print("name" + databaseHandler.GetName());
        // databaseHandler.CreateNewPlayer();
        
    }
    private void OnEnable()
    {
       
    }
    private void OnDisable()
    {
       
    }
    public void StartGame()
    {
        isGameRunning = true;
        isPaused = false;
        Time.timeScale = 1f; 
        Debug.Log("Game Started");
    }


    public void EndGame()
    {
        isGameRunning = false;
        Time.timeScale = 1f;
        Debug.Log("Game Over");
       // Debug.Log("Game Over. Score: " + playerFeesh.GetScore());
       // databaseHandler.SaveScore(playerFeesh.GetScore());
    }

    public void PauseGame()
    {
        if (!isGameRunning || isPaused) return;

        isPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        if (!isGameRunning || !isPaused) return;

        isPaused = false;
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }

    public bool IsPaused() => isPaused;



}
