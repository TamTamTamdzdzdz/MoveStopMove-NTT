using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public Player player;

    public enum GAME_STATE
    {
        PREPARE,
        PLAYING,
        PAUSE,
        FINISH,
    }

    public GAME_STATE gameState = GAME_STATE.PREPARE;
    public bool gameIsPlaying => gameState == GAME_STATE.PLAYING;
   



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void StartGame()
    {
        Debug.Log("gameManager start");
        AIManager.Instance.SpawnAIBot();
        ChangeGameState(GAME_STATE.PLAYING);

    }
    public void PauseGame()
    {
        ChangeGameState(GAME_STATE.PAUSE);
    }
    public void LosingGame()
    {
        ChangeGameState(GAME_STATE.FINISH);
        UIManager.instance.SwitchToLosing();
    }
    public void WinningGame()
    {
        ChangeGameState(GAME_STATE.FINISH);
        UIManager.instance.SwitchToWinning();
    }
    public void ReplayGame()
    {
        ChangeGameState(GAME_STATE.PREPARE);
        UIManager.instance.SwitchToMainMenu();
        AIManager.Instance.ClearAIBot();
        player.OnInit();
        player.Revive();

    }
    public void ResumeGame()
    {
        ChangeGameState(GAME_STATE.PLAYING);
        UIManager.instance.SwitchToInGame();
    }
    public void ChangeGameState(GAME_STATE newGameState)
    {
        if(this.gameState == newGameState) 
            return;
        else
        {
            this.gameState = newGameState;
        }
    }
    public void ChangePlayerName(string newPlayerName)
    {
        player.ChangerPlayerName(newPlayerName);
    }
}
