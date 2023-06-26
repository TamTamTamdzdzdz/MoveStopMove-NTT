using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    [SerializeField] public GameObject inGame;
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject pause;
    [SerializeField] public GameObject winning;
    [SerializeField] public GameObject losing;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        SwitchTo(mainMenu);
    }
    public void DeActiveAll()
    {
        inGame.SetActive(false);
        mainMenu.SetActive(false);
        pause.SetActive(false);
        winning.SetActive(false);
        losing.SetActive(false);
    }
    public void SwitchTo(GameObject UI)
    {
        DeActiveAll();
        UI.gameObject.SetActive(true);
    }
    public void NewGame()
    {
        SwitchTo(inGame);
        if(GameManager.instance == null)
        {
            Debug.Log("error");
            return;
        }

        GameManager.instance.StartGame();
    }
    public void SwitchToInGame()
    {
        SwitchTo(inGame);
    }
    public void SwitchToMainMenu()
    {
        SwitchTo(mainMenu);
    }
    public void SwitchToPause()
    {
        SwitchTo(pause);
        GameManager.instance.PauseGame();
    }
    public void SwitchToLosing()
    {
        SwitchTo(losing);
    }
    public void SwitchToWinning()
    {

        SwitchTo(winning);
    }
}
